using System.Xml;

namespace ProtoBuf.Project
{
    public class MSBuildProject
    {
        const string msbuildNS = "http://schemas.microsoft.com/developer/msbuild/2003";

        XmlDocument xd;

        public void Open(string projectFile)
        {
            xd = new XmlDocument();
            xd.Load(projectFile);
        }

        public void Init(string protoGenPath)
        {
            var xnm = new XmlNamespaceManager(xd.NameTable);
            xnm.AddNamespace("msbuild", msbuildNS);

            string importProject = @"$(ProtoGenPath)\ProtoBuf.MSBuildTask.targets";
            var importNode = xd.SelectSingleNode("/msbuild:Project/msbuild:Import[@Project='" + importProject + "']", xnm);
            if (importNode == null)
            {
                var xe = xd.CreateElement("Import", msbuildNS);
                xe.SetAttribute("Project", importProject);
                importNode = xe;
                xd.DocumentElement.AppendChild(xe);
            }

            var protoGenPathNode = xd.SelectSingleNode("/msbuild:Project/msbuild:PropertyGroup[not(@Condition)]/msbuild:ProtoGenPath", xnm);
            if (protoGenPathNode == null)
            {
                var xe = xd.CreateElement("PropertyGroup", msbuildNS);
                var xe2 = xd.CreateElement("ProtoGenPath", msbuildNS);
                xe2.InnerText = protoGenPath;
                xe.AppendChild(xe2);
                // ensure properties come before targets
                xd.DocumentElement.InsertBefore(xe, importNode);
            }
        }

        public void AddItem(string protoFile)
        {
            var xnm = new XmlNamespaceManager(xd.NameTable);
            xnm.AddNamespace("msbuild", msbuildNS);

            var xe2 = xd.CreateElement("ProtoBuf", msbuildNS);
            xe2.SetAttribute("Include", protoFile);
            var xe3 = xd.CreateElement("Generator", msbuildNS);
            xe3.InnerText = "MSBuild:Compile";
            xe2.AppendChild(xe3);

            var protoBufNode = xd.SelectSingleNode("/msbuild:Project/msbuild:ItemGroup/msbuild:ProtoBuf", xnm);
            if (protoBufNode == null)
            {
                protoBufNode = xd.CreateElement("ItemGroup", msbuildNS);
                var itemGroupNodes = xd.SelectNodes("/msbuild:Project/msbuild:ItemGroup", xnm);
                if (itemGroupNodes.Count > 0)
                    xd.DocumentElement.InsertAfter(protoBufNode, itemGroupNodes[itemGroupNodes.Count - 1]);
                else
                    xd.DocumentElement.AppendChild(protoBufNode);
                protoBufNode.AppendChild(xe2);
            }
            else
                protoBufNode.ParentNode.AppendChild(xe2);
        }

        public void Save(string projectFile)
        {
            xd.Save(projectFile);
        }
    }
}
