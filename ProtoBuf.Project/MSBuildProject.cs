using System.Linq;
using System.Xml;

namespace ProtoBuf.Project
{
    public class MSBuildProject
    {
        const string msbuildNS = "http://schemas.microsoft.com/developer/msbuild/2003";

        XmlDocument xd;

        public string ProtoBufTaskPath { get; private set; }
        public string ProtoGenPath { get; private set; }
        public bool HasProtoBufTaskImport { get; private set; }

        public void Open(string projectFile)
        {
            xd = new XmlDocument();
            xd.Load(projectFile);

            var xnm = new XmlNamespaceManager(xd.NameTable);
            xnm.AddNamespace("msbuild", msbuildNS);
            var protoTaskPathNode = xd.SelectSingleNode("/msbuild:Project/msbuild:PropertyGroup[not(@Condition)]/msbuild:ProtoBufTaskPath", xnm);
            if (protoTaskPathNode != null)
                ProtoBufTaskPath = protoTaskPathNode.InnerText;

            var protoGenPathNode = xd.SelectSingleNode("/msbuild:Project/msbuild:PropertyGroup[not(@Condition)]/msbuild:ProtoGenPath", xnm);
            if (protoGenPathNode != null)
                ProtoGenPath = protoGenPathNode.InnerText;

            string importProject = @"$(ProtoBufTaskPath)ProtoBuf.MSBuildTask.targets";
            var importNode = xd.SelectSingleNode("/msbuild:Project/msbuild:Import[@Project='" + importProject + "']", xnm);
            HasProtoBufTaskImport = importNode != null;
        }

        public string[] LoadItems()
        {
            var xnm = new XmlNamespaceManager(xd.NameTable);
            xnm.AddNamespace("msbuild", msbuildNS);

            var nodes = xd.SelectNodes("/msbuild:Project/msbuild:ItemGroup/msbuild:ProtoBuf", xnm);
            return nodes.Cast<XmlElement>().Select(a => a.GetAttribute("Include")).Where(a => !string.IsNullOrEmpty(a)).ToArray();
        }

        public void Init(string protoBufTaskPath, string protoGenPath)
        {
            var xnm = new XmlNamespaceManager(xd.NameTable);
            xnm.AddNamespace("msbuild", msbuildNS);

            string importProject = @"$(ProtoBufTaskPath)ProtoBuf.MSBuildTask.targets";
            var importNode = xd.SelectSingleNode("/msbuild:Project/msbuild:Import[@Project='" + importProject + "']", xnm);
            if (importNode == null)
            {
                var xe = xd.CreateElement("Import", msbuildNS);
                xe.SetAttribute("Project", importProject);
                importNode = xe;
                xd.DocumentElement.AppendChild(xe);
                HasProtoBufTaskImport = true;
            }

            XmlElement propertyGroupNode;
            var protoBufTaskPathNode = xd.SelectSingleNode("/msbuild:Project/msbuild:PropertyGroup[not(@Condition)]/msbuild:ProtoBufTaskPath", xnm);
            if (protoBufTaskPathNode == null)
            {
                var xe = xd.CreateElement("PropertyGroup", msbuildNS);
                var xe2 = xd.CreateElement("ProtoBufTaskPath", msbuildNS);
                xe2.InnerText = protoBufTaskPath;
                xe.AppendChild(xe2);
                propertyGroupNode = xe;
                // ensure properties come before targets
                xd.DocumentElement.InsertBefore(xe, importNode);
                ProtoBufTaskPath = protoBufTaskPath;
            }
            else
            {
                propertyGroupNode = protoBufTaskPathNode.ParentNode as XmlElement;
                protoBufTaskPathNode.InnerText = protoBufTaskPath;
                ProtoBufTaskPath = protoBufTaskPath;
            }

            var protoGenPathNode = xd.SelectSingleNode("/msbuild:Project/msbuild:PropertyGroup[not(@Condition)]/msbuild:ProtoGenPath", xnm);
            if (protoGenPathNode == null)
            {
                var xe2 = xd.CreateElement("ProtoGenPath", msbuildNS);
                xe2.InnerText = protoGenPath;
                propertyGroupNode.AppendChild(xe2);
                ProtoGenPath = protoGenPath;
            }
            else
            {
                protoGenPathNode.InnerText = protoGenPath;
                ProtoGenPath = protoGenPath;
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

            var protoBufNodes = xd.SelectNodes("/msbuild:Project/msbuild:ItemGroup/msbuild:ProtoBuf", xnm);
            if (protoBufNodes.Count == 0)
            {
                var protoBufNode = xd.CreateElement("ItemGroup", msbuildNS);
                var itemGroupNodes = xd.SelectNodes("/msbuild:Project/msbuild:ItemGroup", xnm);
                if (itemGroupNodes.Count > 0)
                    xd.DocumentElement.InsertAfter(protoBufNode, itemGroupNodes[itemGroupNodes.Count - 1]);
                else
                    xd.DocumentElement.AppendChild(protoBufNode);
                protoBufNode.AppendChild(xe2);
            }
            else
            {
                if (!protoBufNodes.Cast<XmlElement>().Any(a => a.GetAttribute("Include") == protoFile))
                    protoBufNodes[protoBufNodes.Count - 1].ParentNode.AppendChild(xe2);
            }
        }

        public void Save(string projectFile)
        {
            xd.Save(projectFile);
        }
    }
}
