using System.Diagnostics;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Collections.Generic;
using System;

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
            foreach (var item in SourceCodeFiles)
            {
                string output = Path.Combine(OutputPath, Path.GetFileName(item.ItemSpec) + ".g.i.cs");
                string cmd = @"-i:""" + item.ItemSpec + @""" -o:""" + output + @"""";
                Console.Error.WriteLine(ProtoGenExecutable + " " + cmd);
                var process = Process.Start(new ProcessStartInfo(ProtoGenExecutable, cmd) { CreateNoWindow = true, UseShellExecute = false });
                process.WaitForExit();
                list.Add(new TaskItem(output));
            }

            GeneratedCodeFiles = list.ToArray();
            return true;
        }
    }
}
