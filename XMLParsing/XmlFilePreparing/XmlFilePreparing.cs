using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XMLParsing.NodeRealization;


namespace XMLParsing.XmlFileCreation
{
    class XmlFilePreparing
    {
        public static string GetSelectedNodeXmlString(TreeView treeView)
        {
            string xmlFileString = "";
            xmlFileString += "<extract_cadastral_plan_territory>";
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                if (treeView.Nodes[i].Checked)
                {
                    xmlFileString += "<"+treeView.Nodes[i].Name+">";
                }
           
                for (int j = 0; j < treeView.Nodes[i].Nodes.Count; j++)
                { 
                    if (treeView.Nodes[i].Nodes[j].Checked)
                    {
                        xmlFileString += treeView.Nodes[i].Nodes[j].Tag;
                    }
                }

                if (treeView.Nodes[i].Checked)
                {
                    xmlFileString += "</" + treeView.Nodes[i].Name + ">";
                }
            }
            xmlFileString += "</extract_cadastral_plan_territory>";
            return xmlFileString;
        }
    }
}
