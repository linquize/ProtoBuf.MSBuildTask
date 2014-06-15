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

        public string Namespace { get; set; }

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
            if (!string.IsNullOrEmpty(Namespace))
            {
                sb.Append(@"-ns:""");
                sb.Append(Namespace);
                sb.Append(@""" ");
            }

            Log.LogCommandLine(ProtoGenExecutable + " " + sb.ToString());
            var process = Process.Start(new ProcessStartInfo(ProtoGenExecutable, sb.ToString()) { CreateNoWindow = true, UseShellExecute = false, RedirectStandardError = true });
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            if (process.ExitCode == 0)
            {
                if (error.Length > 0)
                    Log.LogWarning(error);
            }
            else
            {
                Log.LogError("protogen failed with exit code {0}", process.ExitCode);
                var reader = new StringReader(error);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    bool parsed = false;
                    do
                    {
                        int i1 = line.IndexOf(':');
                        if (i1 < 0)
                            continue;
                        int i2 = line.IndexOf(':', i1 + 1);
                        if (i2 < 0)
                            continue;
                        int i3 = line.IndexOf(':', i2 + 1);
                        if (i3 < 0)
                            continue;
                        string filename = line.Substring(0, i1);
                        string slineNum = line.Substring(i1 + 1, i2 - i1 - 1);
                        int lineNum;
                        if (!int.TryParse(slineNum, out lineNum))
                            continue;
                        string scolNum = line.Substring(i2 + 1, i3 - i2 - 1);
                        int colNum;
                        if (!int.TryParse(scolNum, out colNum))
                            continue;
                        string message = i3 + 1 < line.Length ? line.Substring(i3 + 1) : "";
                        Log.LogError("", "", "", filename, lineNum, colNum, lineNum, colNum, message);
                        parsed = true;
                    }
                    while (false);
                    if (!parsed)
                        Log.LogError("protogen error: {0}", line);
                }
            }

            list.Add(new TaskItem(output));
            GeneratedCodeFiles = list.ToArray();
            return true;
        }
    }
}
