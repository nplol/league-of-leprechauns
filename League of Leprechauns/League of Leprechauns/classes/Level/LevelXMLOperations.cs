using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace LoL
{
    public class LevelXMLOperations
    {
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

        public static Level ReadLevelFromXML(string levelName)
        {
            XmlDocument doc = new System.Xml.XmlDocument();

            doc.Load(levelName);

            XmlNodeList list = doc["level"].ChildNodes;


            string name = list[0].InnerText;
            string background = list[1].InnerText;
            string soundtheme = list[2].InnerText;

            Level level = new Level(name, background, soundtheme);

            XmlNodeList events = list[3].ChildNodes;
            //XmlNodeList relations = list[4].ChildNodes;

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
            return level;
        }
    }
}
