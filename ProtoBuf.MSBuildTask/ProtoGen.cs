using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ProtoBuf.MSBuildTask
{
    public class ProtoGen : Task
    {
        public ITaskItem[] SourceCodeFiles { get; set; }

        public string OutputPath { get; set; }

        public string ProtoGenExecutable { get; set; }

        [Output]
        public ITaskItem[] GeneratedCodeFiles { get; set; }

        public override bool Execute()
        {
            List<ITaskItem> list = new List<ITaskItem>();
            string output = Path.Combine(OutputPath, "ProtoBuf.g.i.cs");
            StringBuilder sb = new StringBuilder();
            foreach (var item in SourceCodeFiles)
            {
                sb.Append(@"-i:""");
                sb.Append(item.ItemSpec);
                sb.Append(@""" ");
            }
            sb.Append(@"-o:""");
            sb.Append(output);
            sb.Append(@""" ");
            Console.Error.WriteLine(ProtoGenExecutable + " " + sb.ToString());
            var process = Process.Start(new ProcessStartInfo(ProtoGenExecutable, sb.ToString()) { CreateNoWindow = true, UseShellExecute = false });
            process.WaitForExit();
            list.Add(new TaskItem(output));
            GeneratedCodeFiles = list.ToArray();
            return true;
        }
    }
}
