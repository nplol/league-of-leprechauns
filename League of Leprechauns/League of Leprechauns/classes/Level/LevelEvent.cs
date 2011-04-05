using System.Xml;
using Microsoft.Xna.Framework;

namespace LoL
{
    public abstract class LevelEvent
    {
        internal int eventID;

        public LevelEvent() { }

        public LevelEvent(XmlNode node)
        {
            this.Read(node);
        }

        public int EventID
        {
            get { return eventID; }
        }

        protected abstract void Read(XmlNode node);
        public abstract XmlElement Write(XmlDocument doc, int id);
        public abstract void Execute();

        protected Vector2 ParseVector2(string text)
        {
            int x = int.Parse(text.Substring(0, text.IndexOf(' ')));
            int y = int.Parse(text.Substring(text.IndexOf(' ') + 1));

            return new Vector2(x, y);
        }   
    }
}
