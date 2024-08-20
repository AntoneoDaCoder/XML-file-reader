namespace Дешифратор_XML_эдишн
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.DataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.ProcessFileButton = new System.Windows.Forms.Button();
            this.ResultsPreviewLabel = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.OpenFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.NumEntriesLabel = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.Menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(803, 33);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // DataMenuItem
            // 
            this.DataMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileItem,
            this.FolderMenuItem,
            this.SaveFileItem});
            this.DataMenuItem.Name = "DataMenuItem";
            this.DataMenuItem.Size = new System.Drawing.Size(91, 29);
            this.DataMenuItem.Text = "Данные";
            // 
            // OpenFileItem
            // 
            this.OpenFileItem.Name = "OpenFileItem";
            this.OpenFileItem.Size = new System.Drawing.Size(260, 34);
            this.OpenFileItem.Text = "Открыть файл(-ы)";
            this.OpenFileItem.Click += new System.EventHandler(this.OpenFileItem_Click);
            // 
            // FolderMenuItem
            // 
            this.FolderMenuItem.Name = "FolderMenuItem";
            this.FolderMenuItem.Size = new System.Drawing.Size(260, 34);
            this.FolderMenuItem.Text = "Открыть папку";
            this.FolderMenuItem.Click += new System.EventHandler(this.FolderMenuItem_Click);
            // 
            // SaveFileItem
            // 
            this.SaveFileItem.Enabled = false;
            this.SaveFileItem.Name = "SaveFileItem";
            this.SaveFileItem.Size = new System.Drawing.Size(260, 34);
            this.SaveFileItem.Text = "Сохранить в файл";
            this.SaveFileItem.Click += new System.EventHandler(this.SaveFileItem_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.Filter = "|*.xml";
            this.OpenDialog.Multiselect = true;
            // 
            // SaveDialog
            // 
            this.SaveDialog.DefaultExt = "txt";
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(12, 139);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(776, 263);
            this.OutputBox.TabIndex = 1;
            this.OutputBox.Text = "";
            this.OutputBox.TextChanged += new System.EventHandler(this.OutputBox_TextChanged);
            // 
            // ProcessFileButton
            // 
            this.ProcessFileButton.Enabled = false;
            this.ProcessFileButton.Location = new System.Drawing.Point(12, 56);
            this.ProcessFileButton.Name = "ProcessFileButton";
            this.ProcessFileButton.Size = new System.Drawing.Size(330, 37);
            this.ProcessFileButton.TabIndex = 2;
            this.ProcessFileButton.Text = "Обработать";
            this.ProcessFileButton.UseVisualStyleBackColor = true;
            this.ProcessFileButton.Click += new System.EventHandler(this.ProcessFileButton_Click);
            // 
            // ResultsPreviewLabel
            // 
            this.ResultsPreviewLabel.AutoSize = true;
            this.ResultsPreviewLabel.Location = new System.Drawing.Point(12, 116);
            this.ResultsPreviewLabel.Name = "ResultsPreviewLabel";
            this.ResultsPreviewLabel.Size = new System.Drawing.Size(228, 20);
            this.ResultsPreviewLabel.TabIndex = 4;
            this.ResultsPreviewLabel.Text = "Предпросмотр результатов:";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 456);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(776, 189);
            this.LogBox.TabIndex = 5;
            this.LogBox.Text = "";
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 433);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(161, 20);
            this.LogLabel.TabIndex = 6;
            this.LogLabel.Text = "Логи расшифровки:";
            // 
            // NumEntriesLabel
            // 
            this.NumEntriesLabel.AutoSize = true;
            this.NumEntriesLabel.Location = new System.Drawing.Point(376, 64);
            this.NumEntriesLabel.Name = "NumEntriesLabel";
            this.NumEntriesLabel.Size = new System.Drawing.Size(260, 20);
            this.NumEntriesLabel.TabIndex = 7;
            this.NumEntriesLabel.Text = "Всего деклараций обработано: 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 656);
            this.Controls.Add(this.NumEntriesLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.ResultsPreviewLabel);
            this.Controls.Add(this.ProcessFileButton);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "MainForm";
            this.Text = "Дешифратор";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem DataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileItem;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button ProcessFileButton;
        private System.Windows.Forms.Label ResultsPreviewLabel;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.ToolStripMenuItem FolderMenuItem;
        private System.Windows.Forms.FolderBrowserDialog OpenFolderDialog;
        private System.Windows.Forms.Label NumEntriesLabel;
    }
}

