using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XMLParsing.NodeRealization;
using XMLParsing.XmlFileCreation;

namespace XMLParsing
{    
    abstract class NodeProperties
    {
        private XmlDocument xml;
        private XmlNode noDataNode;
        private string noDataXmlString = "<nodata><nodatarec>Нет данных</nodatarec><nodatarec>Нет данных</nodatarec></nodata>";

        private XmlNode rootNode;
        private XmlNodeList unicIdNode;
        private XmlNodeList nodeContent;
        protected NodeProperties()
        {
            xml = new XmlDocument();
            xml.LoadXml(noDataXmlString);
            noDataNode = xml.DocumentElement;
        }

        protected XmlNode RootNode
        {
            get => rootNode;
            set
            {
                if (value == null)
                {
                    rootNode = noDataNode;
                }
                else
                {
                    rootNode = value;
                }
            }
        }

        protected XmlNodeList UnicIdNode
        {
            get=> unicIdNode;
            set
            {
                if (value == null || value.Count == 0)
                {
                    unicIdNode = noDataNode.ChildNodes;
                }
                else
                {
                    unicIdNode = value;
                }
            }
        }

        protected XmlNodeList NodeContent
        {
            get => nodeContent;
            set
            {
                if (value == null || value.Count==0)
                {
                    nodeContent = noDataNode.ChildNodes;
                }
                else
                {
                    nodeContent = value;
                }
            }
        }

        public static void AddNodePropertiesToTreeView(TreeView treeView, NodeProperties nodeProperties)
        {
            TreeNode rootTreeNode = new TreeNode(nodeProperties.RootNode.Name);
            rootTreeNode.Name = nodeProperties.RootNode.Name;
            rootTreeNode.Text = nodeProperties.GetType().Name;
            rootTreeNode.Tag = nodeProperties.RootNode.OuterXml;           

            treeView.Nodes.Add(rootTreeNode);//добавление корневого элемента (1 узел)

            TreeNode unicIdNode;
            for (int i = 0; i < nodeProperties.UnicIdNode.Count; i++)
            {
                unicIdNode = new TreeNode(nodeProperties.UnicIdNode[i].InnerText);                
                unicIdNode.Name=nodeProperties.UnicIdNode[i].InnerText;
                
                rootTreeNode.Nodes.Add(unicIdNode);//добавление уникальных идентификаторов (2 узел)                           
            }
            for (int i = 0; i < nodeProperties.NodeContent.Count; i++)
            {
                rootTreeNode.Nodes[i].Tag = nodeProperties.NodeContent[i].OuterXml; // сохранение контента
            }
        }
    }
}
