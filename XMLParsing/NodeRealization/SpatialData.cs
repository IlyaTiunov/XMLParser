using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParsing.NodeRealization
{
    class SpatialData:NodeProperties
    {
        public void GetSpatialData(XmlElement root)
        {
            XmlNode xmlRootElement = root.SelectSingleNode("//spatial_data");
            XmlNodeList unicRootNodeIds = root.SelectNodes("//spatial_data/entity_spatial/sk_id");
            XmlNodeList xmlRootChildElements = root.SelectNodes("//spatial_data/entity_spatial");

            RootNode = xmlRootElement;
            UnicIdNode = unicRootNodeIds;
            NodeContent = xmlRootChildElements;
        }
    }
}
