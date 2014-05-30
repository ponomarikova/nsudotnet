using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ponomarikova.Nsudonet.Rss2Email
{
    static class XMLUtils
    {
        public static string GetTextFromXML(string xml)
        {
            StringBuilder text = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(xml))
            {
                bool isText = false;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch(reader.Name)
                            {
                                case "title":
                                    text.Append("Title : ");
                                    isText = true;
                                    break;
                                case "link":
                                    text.Append("Link : ");
                                    isText = true;
                                    break;
                                case "description":
                                    text.Append("Description : ");
                                    isText = true;
                                    break;
                            }
                            break;

                        case XmlNodeType.Text:
                            if(isText)
                            {
                                text.AppendLine(reader.Value);
                                isText = false;
                            }
                            break;

                        case XmlNodeType.EndElement:
                            switch (reader.Name)
                            {
                                case "title":
                                case "link":
                                case "description":
                                    isText = false;
                                    text.AppendLine("");
                                    break;
                            }
                            break;
                    }
                }
            }

            return text.ToString();
        }
    }
}
