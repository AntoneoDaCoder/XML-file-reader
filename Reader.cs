using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Дешифратор_XML_эдишн
{
    internal class Reader
    {
        const int THREAD_NUM = 8;
        readonly List<List<string>> FileNames = new List<List<string>>();
        static List<ReaderResponse> Responses;
        static Mutex ResponsesMutex;
        static Mutex LogMutex;
        static readonly XmlReaderSettings Settings = new XmlReaderSettings();
        static CountdownEvent QueuedMethods;
        List<string> Logs;
        readonly RichTextBox LogBox, OutputBox;
        public int NumEntries { get; private set; }
        public Reader(List<string> fileNames, RichTextBox LogBox, RichTextBox OutputBox)
        {
            Responses = new List<ReaderResponse>();
            ResponsesMutex = new Mutex();
            LogMutex = new Mutex();
            Logs = new List<string>();
            if (fileNames.Count < THREAD_NUM)
                FileNames.Add(fileNames);
            else
            {
                int chunkSize = fileNames.Count / THREAD_NUM;
                int i = 0;
                for (; i < chunkSize * THREAD_NUM - 1; i += chunkSize)
                    FileNames.Add(fileNames.GetRange(i, chunkSize));
                if (i < fileNames.Count)
                {
                    FileNames.Last().AddRange(fileNames.GetRange(i, fileNames.Count - i));
                }
            }
            Settings.IgnoreWhitespace = true;
            this.LogBox = LogBox;
            this.OutputBox = OutputBox;
        }
        string ExtractConsignee(XmlReader consigneeReader)
        {
            StringBuilder consignee = new StringBuilder();
            consigneeReader.ReadToFollowing("cacdo:ConsigneeDetails");
            using (XmlReader innerReader = consigneeReader.ReadSubtree())
            {
                innerReader.ReadToDescendant("csdo:SubjectBriefName");
                consignee.Append(innerReader.ReadElementContentAsString());
            }
            return consignee.ToString();
        }
        string ExtractInvoice(XmlReader invoiceReader)
        {
            StringBuilder invoice = new StringBuilder();
            invoiceReader.ReadToFollowing("cacdo:PresentedDocDetails");
            bool invoiceWasFound = false;
            while (invoiceReader.NodeType != XmlNodeType.EndElement && invoiceReader.Name != "cacdo:DeclarationGoodsShipmentDetails" && !invoiceWasFound)
            {
                using (XmlReader innerReader = invoiceReader.ReadSubtree())
                {
                    innerReader.ReadToDescendant("csdo:DocKindCode");
                    string temp = innerReader.ReadElementContentAsString();
                    if (temp == "04021")
                    {
                        invoice.Append(temp);
                        invoice.Append(" " + innerReader.ReadElementContentAsString());
                        invoice.Append(" " + innerReader.ReadElementContentAsString());
                        invoiceWasFound = true;
                    }
                }
                invoiceReader.Read();
            }
            return invoice.ToString();
        }
        bool CheckIfDocumentIsSigned(XmlReader reader)
        {
            return reader.ReadToFollowing("Signature");
        }
        string CheckResponse(ReaderResponse response)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n----------------------------------------------------------------------------------------------------------");
            sb.Append("\nFile ID: " + (response.DocId != null ? response.DocId + ", " : "error, "));
            sb.Append("Signed: " + (response.IsSigned ? "yes, " : "no, "));
            sb.Append("Consignee Name: " + (response.ConsigneeName != null ? "ok, " : "error, "));
            sb.Append("Document Sum: " + (response.DocumentSum > 0 ? "ok, " : "error, "));
            sb.Append("Invoice: " + (response.Invoice != null ? "ok, " : "error, "));
            if (!response.IsSigned)
            {
                sb.Append($"Comments: {response.Comments.Count} ");
                if (response.Comments.Count > 0 && response.Comments.Count < 4)
                {
                    sb.Append("{");
                    foreach (var comment in response.Comments)
                    {
                        sb.Append(comment + ", ");
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append("}");
                }

            }
            else
                sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
        ReaderResponse ReadFile(string filename)
        {
            var result = new ReaderResponse();
            XmlReader reader = XmlReader.Create(filename, Settings);
            reader.ReadToFollowing("csdo:EDocId");
            result.DocId = reader.ReadElementContentAsString();
            reader.ReadToFollowing("casdo:CAValueAmount");
            result.DocumentSum = reader.ReadElementContentAsDouble();
            result.ConsigneeName = ExtractConsignee(reader);
            result.Invoice = ExtractInvoice(reader);
            result.IsSigned = CheckIfDocumentIsSigned(reader);
            if (!result.IsSigned)
            {
                reader.Close();
                reader.Dispose();
                reader = XmlReader.Create(filename, Settings);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Comment)
                    {
                        if (reader.Value.Contains("D_EXP:") || reader.Value.Contains("NOM_REG") || reader.Value.Contains("NOM_RAZR") || reader.Value.Contains("DT_DATE") || reader.Value.Contains("DATE_RAZR"))
                            result.Comments.Add(reader.Value.Trim());
                    }
                }
            }
            reader.Close();
            reader.Dispose();
            return result;
        }
        void ReadFiles(object data)
        {
            List<string> files = data as List<string>;
            List<ReaderResponse> tempResponsesBuf = new List<ReaderResponse>();
            var actualFiles = from file in files where file.Contains(".xml") select file;
            foreach (var file in actualFiles)
            {
                tempResponsesBuf.Add(ReadFile(file));
                LogMutex.WaitOne();
                Logs.Add(CheckResponse(tempResponsesBuf.Last()));
                LogMutex.ReleaseMutex();
            }
            ResponsesMutex.WaitOne();
            Responses.AddRange(tempResponsesBuf);
            QueuedMethods.Signal();
            ResponsesMutex.ReleaseMutex();
        }
        void ParseLogs()
        {
            foreach (var log in Logs)
                LogBox.AppendText(log);
        }
        void FillPreview()
        {
            foreach (var response in Responses)
                OutputBox.AppendText(response.ToString());
        }
        public static void ExportToFile(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var response in Responses)
                sb.Append(response.ToString());
            File.AppendAllText(fileName, sb.ToString());
        }
        public void StartFileProcessing()
        {
            QueuedMethods = new CountdownEvent(FileNames.Count);
            foreach (var list in FileNames)
                ThreadPool.QueueUserWorkItem(ReadFiles, list);
            QueuedMethods.Wait();
            ParseLogs();
            FillPreview();
            NumEntries = Responses.Count;
        }
    }
}
