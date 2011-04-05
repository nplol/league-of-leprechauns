using System.Xml;

namespace LoL
{
    /// <summary>
    /// Provides methods for loading and saving levels from/to xml.
    /// </summary>
    public class LevelXMLOperations
    {
        /// <summary>
        /// Writes a level to a XML file.
        /// </summary>
        /// <param name="level">The level do save</param>
        /// <param name="path">Path to the level file</param>
        public static void WriteLevelToXML(Level level, string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            XmlElement root = doc.CreateElement("level");
            doc.AppendChild(root);

            XmlElement element = doc.CreateElement("name");
            element.InnerText = level.LevelName;
            root.AppendChild(element);

            element = doc.CreateElement("background");
            element.InnerText = level.Background;
            root.AppendChild(element);

            element = doc.CreateElement("soundtheme");
            element.InnerText = level.Sound;
            root.AppendChild(element);

            XmlElement events = doc.CreateElement("events");
            root.AppendChild(events);

            int globalEventID = 0;

            foreach (LevelEvent levelEvent in level.events)
            {
                events.AppendChild(levelEvent.Write(doc, ++globalEventID));

            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(path, settings);

            doc.WriteContentTo(writer);
            writer.Close();
        }

        /// <summary>
        /// Reads a level from XML.
        /// </summary>
        /// <param name="path">Path to the level file</param>
        /// <returns></returns>
        public static Level ReadLevelFromXML(string path)
        {
            XmlDocument doc = new System.Xml.XmlDocument();

            doc.Load(path);

            XmlNodeList list = doc["level"].ChildNodes;


            string name = list[0].InnerText;
            string background = list[1].InnerText;
            string soundtheme = list[2].InnerText;

            Level level = new Level(name, background, soundtheme);

            XmlNodeList events = list[3].ChildNodes;
            XmlNodeList relations = list[4].ChildNodes;

            foreach (XmlNode node in events)
            {
                switch (node["eventType"].InnerText)
                {
                    case "ActorSpawn":
                        level.AddEvent(new ActorSpawnEvent(node));
                        break;
                    case "Text":
                        level.AddEvent(new TextEvent(node));
                        break;
                    case "EndGame":
                        level.AddEvent(new EndGameEvent(node));
                        break;
                    case "Dialog":
                        level.AddEvent(new DialogEvent(node));
                        break;

                    default: break;
                }
            }

            foreach (XmlNode node in relations)
            {
                int actor1 = int.Parse(node.InnerText.Substring(0, node.InnerText.IndexOf(' ')));
                int actor2 = int.Parse(node.InnerText.Substring(node.InnerText.IndexOf(' ') + 1));
               
                level.AddRelation(actor1, actor2);
            }

            return level;
        }
    }
}