using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Дешифратор_XML_эдишн
{
    public partial class MainForm : Form
    {
        string[] Files;
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenFileItem_Click(object sender, EventArgs e)
        {
            OutputBox.Clear();
            LogBox.Clear();
            ProcessFileButton.Enabled = false;
            SaveFileItem.Enabled = false;
            NumEntriesLabel.Text = "Всего деклараций обработано: 0";
            if (OpenDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ProcessFileButton.Enabled = true;
            Files = OpenDialog.FileNames;
        }

        private void SaveFileItem_Click(object sender, EventArgs e)
        {
            if (SaveDialog.ShowDialog() == DialogResult.Cancel)
                return;
            Reader.ExportToFile(SaveDialog.FileName);
        }

        private void ProcessFileButton_Click(object sender, EventArgs e)
        {
            OutputBox.Clear();
            LogBox.Clear();
            Reader xmlDeclarationReader = new Reader(new List<string>(Files), LogBox, OutputBox);
            xmlDeclarationReader.StartFileProcessing();
            NumEntriesLabel.Text = "Всего деклараций обработано: " + xmlDeclarationReader.NumEntries;
        }

        private void OutputBox_TextChanged(object sender, EventArgs e)
        {
            if (OutputBox.Text.Length > 0)
                SaveFileItem.Enabled = true;
            else
                SaveFileItem.Enabled = false;
        }

        private void FolderMenuItem_Click(object sender, EventArgs e)
        {
            OutputBox.Clear();
            LogBox.Clear();
            ProcessFileButton.Enabled = false;
            SaveFileItem.Enabled = false;
            NumEntriesLabel.Text = "Всего деклараций обработано: 0";
            if (OpenFolderDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ProcessFileButton.Enabled = true;
            string selectedPath = OpenFolderDialog.SelectedPath;
            Files = Directory.GetFiles(selectedPath);
        }
    }
}
