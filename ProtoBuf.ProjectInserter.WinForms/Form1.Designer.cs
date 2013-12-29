namespace ProtoBuf.ProjectInserter.WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.ofd2 = new System.Windows.Forms.OpenFileDialog();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtProtoGenPath = new System.Windows.Forms.TextBox();
            this.lsbFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 33);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(200, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open Project";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnInit
            // 
            this.btnInit.Enabled = false;
            this.btnInit.Location = new System.Drawing.Point(12, 62);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(200, 23);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "Initialize ProtoBuf MSBuildTask";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Enabled = false;
            this.btnAddFiles.Location = new System.Drawing.Point(12, 91);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(200, 23);
            this.btnAddFiles.TabIndex = 2;
            this.btnAddFiles.Text = "Add ProtoBuf Files";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(12, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Project";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(218, 36);
            this.txtProject.Name = "txtProject";
            this.txtProject.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(437, 20);
            this.txtProject.TabIndex = 4;
            // 
            // ofd1
            // 
            this.ofd1.Filter = "Visual Studio Project Files (*.csproj)|*.csproj";
            this.ofd1.RestoreDirectory = true;
            // 
            // ofd2
            // 
            this.ofd2.Filter = "ProtoBuf Files (*.proto)|*.proto";
            this.ofd2.Multiselect = true;
            this.ofd2.RestoreDirectory = true;
            // 
            // txtProtoGenPath
            // 
            this.txtProtoGenPath.Location = new System.Drawing.Point(218, 65);
            this.txtProtoGenPath.Name = "txtProtoGenPath";
            this.txtProtoGenPath.ReadOnly = true;
            this.txtProtoGenPath.Size = new System.Drawing.Size(437, 20);
            this.txtProtoGenPath.TabIndex = 5;
            // 
            // lsbFiles
            // 
            this.lsbFiles.FormattingEnabled = true;
            this.lsbFiles.Location = new System.Drawing.Point(219, 91);
            this.lsbFiles.Name = "lsbFiles";
            this.lsbFiles.Size = new System.Drawing.Size(227, 238);
            this.lsbFiles.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 340);
            this.Controls.Add(this.lsbFiles);
            this.Controls.Add(this.txtProtoGenPath);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ProtoBuf Project Inserter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.OpenFileDialog ofd2;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.TextBox txtProtoGenPath;
        private System.Windows.Forms.ListBox lsbFiles;
    }
}

