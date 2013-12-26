using System;
using System.Windows.Forms;
using ProtoBuf.Project;
using System.IO;

namespace ProtoBuf.ProjectInserter.WinForms
{
    public partial class Form1 : Form
    {
        MSBuildProject project;
        string projectFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofd1.ShowDialog() != DialogResult.OK) return;
            project = new MSBuildProject();
            project.Open(ofd1.FileName);
            projectFile = ofd1.FileName;
            txtProject.Text = projectFile;
            txtProtoGenPath.Text = project.ProtoGenPath;
            btnInit.Enabled = true;
            btnAddFiles.Enabled = btnSave.Enabled = (project.HasProtoGenImport && !string.IsNullOrEmpty(project.ProtoGenPath));
            lsbFiles.Items.Clear();
            lsbFiles.Items.AddRange(project.LoadItems());
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            fbd1.SelectedPath = MakeAbsoluteFileName(project.ProtoGenPath ?? "");
            if (fbd1.ShowDialog() != DialogResult.OK) return;
            string protoGenPath = GetRelativeFileName(fbd1.SelectedPath + Path.DirectorySeparatorChar);
            protoGenPath = protoGenPath == "" ? "." : protoGenPath;
            protoGenPath += protoGenPath.EndsWith(Path.DirectorySeparatorChar.ToString()) ? "" : Path.DirectorySeparatorChar.ToString();
            project.Init(protoGenPath);
            txtProtoGenPath.Text = project.ProtoGenPath;
            btnAddFiles.Enabled = btnSave.Enabled = true;
        }

        string MakeAbsoluteFileName(string s)
        {
            string pd = Path.Combine(Path.GetDirectoryName(projectFile), s);
            var uri = new Uri(pd);
            return uri.AbsolutePath.Replace('/', Path.DirectorySeparatorChar);
        }

        string GetRelativeFileName(string s)
        {
            string pd = Path.GetDirectoryName(projectFile) + Path.DirectorySeparatorChar;
            var uri = new Uri(pd).MakeRelativeUri(new Uri(s));
            return uri.OriginalString.Replace('/', Path.DirectorySeparatorChar);
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            if (ofd2.ShowDialog() != DialogResult.OK) return;
            foreach (var file in ofd2.FileNames)
                project.AddItem(GetRelativeFileName(file));
            lsbFiles.Items.Clear();
            lsbFiles.Items.AddRange(project.LoadItems());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            project.Save(projectFile);
        }
    }
}
