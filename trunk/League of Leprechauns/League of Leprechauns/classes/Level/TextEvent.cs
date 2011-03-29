using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class TextEvent : LevelEvent
    {
        string text;
        string spriteFont;
        Vector2 position;

        public TextEvent(XmlNode node) : base(node) { }

        protected override void Read(System.Xml.XmlNode node)
        {
            this.eventID = int.Parse(node["eventID"].InnerText);
            this.spriteFont = node["spriteFont"].InnerText;
            this.text = node["text"].InnerText;
            this.position = ParseVector2(node["position"].InnerText);
        }

        public override XmlElement Write(XmlDocument doc, int id)
        {
            XmlElement eventElement = doc.CreateElement("event");

            XmlElement element = doc.CreateElement("eventType");
            element.InnerText = "Text";
            eventElement.AppendChild(element);

            element = doc.CreateElement("eventID");
            element.InnerText = id.ToString();
            eventElement.AppendChild(element);

            element = doc.CreateElement("spriteFont");
            element.InnerText = spriteFont;
            eventElement.AppendChild(element);

            element = doc.CreateElement("text");
            element.InnerText = text;
            eventElement.AppendChild(element);

            element = doc.CreateElement("position");
            element.InnerText = position.X.ToString() + " " + position.Y.ToString();
            eventElement.AppendChild(element);

            return eventElement;
        }

        public override void Execute()
        {

        }
    }
}
