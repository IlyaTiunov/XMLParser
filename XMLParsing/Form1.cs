using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using XMLParsing.NodeRealization;

using XMLParsing.XmlFileCreation;

namespace XMLParsing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xmlfilePath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlfilePath = openFileDialog.FileName;

                string xmlString = File.ReadAllText(xmlfilePath, Encoding.UTF8);

                XmlDocument dom = new XmlDocument();
                dom.LoadXml(xmlString);

                XmlElement root = dom.DocumentElement;

                    treeView1.Nodes.Clear();

                    Parcels parcels = new Parcels();
                    parcels.GetParcels(root);
                    NodeProperties.AddNodePropertiesToTreeView(treeView1, parcels);

                    ObjectRealty objectRealty = new ObjectRealty();
                    objectRealty.GetObjectRealty(root);
                    NodeProperties.AddNodePropertiesToTreeView(treeView1, objectRealty);

                    SpatialData spatialData = new SpatialData();
                    spatialData.GetSpatialData(root);
                    NodeProperties.AddNodePropertiesToTreeView(treeView1, spatialData);

                    Bounds bounds = new Bounds();
                    bounds.GetBounds(root);
                    NodeProperties.AddNodePropertiesToTreeView(treeView1, bounds);

                    Zones zones = new Zones();
                    zones.GetZones(root);
                    NodeProperties.AddNodePropertiesToTreeView(treeView1, zones);
            }
            else
            {
                MessageBox.Show("Отмена операции");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count > 0) 
            {
                string xmlfilePath = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML files (*.xml)|*.xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xmlfilePath = saveFileDialog.FileName;
                }

                string selectedNodeXmlString = XmlFilePreparing.GetSelectedNodeXmlString(treeView1);

                XmlDocument newXmlDom= new XmlDocument();
                newXmlDom.LoadXml(selectedNodeXmlString);

                newXmlDom.Save(xmlfilePath);
                MessageBox.Show("Файл сохранен");
            }
            else
            {
                { MessageBox.Show("Нет элементов для сохранения"); }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                if (e.Node.Nodes[i].Checked)
                {
                    e.Node.Nodes[i].Checked = false;
                }
                else
                {
                    e.Node.Nodes[i].Checked = true;
                }    
            }            
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpProvider1 = new System.Windows.Forms.HelpProvider();
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.HelpNamespace = "help.html";

            Process proc = new Process();
            proc.StartInfo.FileName = "help.html";
            proc.Start();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                TreeNode treeNode = e.Node;

                textBox1.Text = "";

                string selectedNodeXmlString = "";
                selectedNodeXmlString += "<extract_cadastral_plan_territory>";
                selectedNodeXmlString += treeNode.Tag;
                selectedNodeXmlString += "</extract_cadastral_plan_territory>";

                var xmlFormatted = XDocument.Parse(selectedNodeXmlString).ToString();

                textBox1.Multiline = true;
                textBox1.Text = xmlFormatted;
            }
            else
            {
                textBox1.Text = "";
            }         
        }
    }
}
