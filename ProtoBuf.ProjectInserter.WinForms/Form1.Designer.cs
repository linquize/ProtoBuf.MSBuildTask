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
            this.txtProtoBufTaskPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(122, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open Project";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnInit
            // 
            this.btnInit.Enabled = false;
            this.btnInit.Location = new System.Drawing.Point(12, 39);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(122, 46);
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
            this.btnAddFiles.Size = new System.Drawing.Size(122, 23);
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
            this.btnSave.Size = new System.Drawing.Size(122, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Project";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(240, 12);
            this.txtProject.Name = "txtProject";
            this.txtProject.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(415, 20);
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
            this.txtProtoGenPath.Location = new System.Drawing.Point(240, 65);
            this.txtProtoGenPath.Name = "txtProtoGenPath";
            this.txtProtoGenPath.ReadOnly = true;
            this.txtProtoGenPath.Size = new System.Drawing.Size(415, 20);
            this.txtProtoGenPath.TabIndex = 5;
            // 
            // lsbFiles
            // 
            this.lsbFiles.FormattingEnabled = true;
            this.lsbFiles.Location = new System.Drawing.Point(240, 91);
            this.lsbFiles.Name = "lsbFiles";
            this.lsbFiles.Size = new System.Drawing.Size(227, 238);
            this.lsbFiles.TabIndex = 6;
            // 
            // txtProtoBufTaskPath
            // 
            this.txtProtoBufTaskPath.Location = new System.Drawing.Point(240, 39);
            this.txtProtoBufTaskPath.Name = "txtProtoBufTaskPath";
            this.txtProtoBufTaskPath.ReadOnly = true;
            this.txtProtoBufTaskPath.Size = new System.Drawing.Size(416, 20);
            this.txtProtoBufTaskPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ProtoBufTaskPath";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "ProtoGenPath";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "ProtoBuf files";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(165, 116);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(40, 13);
            this.lblFileCount.TabIndex = 12;
            this.lblFileCount.Text = "(count)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 340);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProtoBufTaskPath);
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
        private System.Windows.Forms.TextBox txtProtoBufTaskPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFileCount;
    }
}

