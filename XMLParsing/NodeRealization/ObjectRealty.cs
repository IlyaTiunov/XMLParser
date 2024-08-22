using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParsing.NodeRealization
{
    class ObjectRealty:NodeProperties
    {
        public void GetObjectRealty(XmlElement root)
        {//------------------------------------------------------Создание нового элемента-----------------------------------------------
            XmlNodeList buildRecordXmlNodes = root.SelectNodes("//build_record");
            XmlNodeList contructionRecordXmlNodes = root.SelectNodes("//construction_record");

            string xmlRootElementsString = "";
            xmlRootElementsString += "<build_records_and_construction_records>";
           
            for (int i=0;i< buildRecordXmlNodes.Count;i++)
            {
                xmlRootElementsString += "<build_record>";
                xmlRootElementsString += buildRecordXmlNodes[i].InnerXml;
                xmlRootElementsString += "</build_record>";
            }            
           
            for (int i = 0; i < contructionRecordXmlNodes.Count; i++)
            {
                xmlRootElementsString += "<construction_record>";
                xmlRootElementsString += contructionRecordXmlNodes[i].InnerXml;
                xmlRootElementsString += "</construction_record>";
            }
           
            xmlRootElementsString += "</build_records_and_construction_records>";
           
            XmlDocument objectRealtyDom = new XmlDocument();
            objectRealtyDom.LoadXml(xmlRootElementsString);//неразделимые элементы в новом dom

            XmlNode xmlRootElement = objectRealtyDom.DocumentElement; //корень
 //------------------------------------------------------------------------------------------------------------------------
            XmlNodeList unicRootNodeIds = root.SelectNodes("//construction_record/object/common_data/cad_number | //build_record/object/common_data/cad_number"); //cad корневого
            XmlNodeList xmlRootChildElements = root.SelectNodes("//build_record | //construction_record");

            RootNode = xmlRootElement;
            UnicIdNode = unicRootNodeIds;
            NodeContent = xmlRootChildElements;
        }

    }
}
