using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace XMLParsing.NodeRealization
{
    class Parcels:NodeProperties
    {
        public void GetParcels(XmlElement root)
        {
            XmlNode xmlRootElement = root.SelectSingleNode("//land_records"); //корневой
            XmlNodeList unicRootNodeIds = root.SelectNodes("//land_records/land_record/object/common_data/cad_number"); //cad корневого
            XmlNodeList xmlRootChildElements = root.SelectNodes("//land_record");

            RootNode = xmlRootElement;
            UnicIdNode = unicRootNodeIds;
            NodeContent = xmlRootChildElements; //дочерние элементы корневого   
        }
    }
}
