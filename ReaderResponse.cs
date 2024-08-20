using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дешифратор_XML_эдишн
{
    internal class ReaderResponse
    {
        public string DocId { get; set; }
        public string ConsigneeName { get; set; }
        public double DocumentSum { get; set; }
        public string Invoice { get; set; }
        public List<string> Comments { get; set; }
        public bool IsSigned { get; set; }
        public ReaderResponse()
        {
            Comments = new List<string>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DocId + ";");
            sb.Append(ConsigneeName + ";");
            sb.Append(DocumentSum + ";");
            sb.Append(Invoice + ";");
            if (Comments.Count > 0)
            {
                foreach (var comment in Comments)
                    sb.Append(comment + ";");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.Append("\n").ToString();
        }
    }
}
