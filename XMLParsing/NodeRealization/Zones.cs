using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParsing.NodeRealization
{
    class Zones:NodeProperties
    {
        public void GetZones(XmlElement root)
        {
            XmlNode xmlRootElement = root.SelectSingleNode("//zones_and_territories_boundaries"); //корневой
            XmlNodeList unicRootNodeIds = root.SelectNodes("//zones_and_territories_boundaries/zones_and_territories_record/b_object_zones_and_territories/b_object/reg_numb_border");
            XmlNodeList xmlRootChildElements = root.SelectNodes("//zones_and_territories_record");

            RootNode = xmlRootElement;
            UnicIdNode = unicRootNodeIds;
            NodeContent = xmlRootChildElements;
        }
    }
}
