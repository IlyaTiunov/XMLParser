using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParsing.NodeRealization
{
    class Bounds:NodeProperties
    {
        public void GetBounds(XmlElement root)
        {
            XmlNode xmlRootElement = root.SelectSingleNode("//municipal_boundaries");
            XmlNodeList unicRootNodeIds = root.SelectNodes("//municipal_boundaries/municipal_boundary_record/b_object_municipal_boundary/b_object/reg_numb_border");
            XmlNodeList xmlRootChildElements = root.SelectNodes("//municipal_boundary_record");

            RootNode = xmlRootElement;
            UnicIdNode = unicRootNodeIds;
            NodeContent = xmlRootChildElements;
        }
    }
}
