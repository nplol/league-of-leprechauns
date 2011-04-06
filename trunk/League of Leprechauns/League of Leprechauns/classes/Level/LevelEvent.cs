using System.Xml;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Base class containing necessary methods for a level event. 
    /// </summary>
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

        /// <summary>
        /// Reads in data from the XmlNode
        /// </summary>
        /// <param name="node">XmlNode containing event data</param>
        protected abstract void Read(XmlNode node);
        /// <summary>
        /// Writes event data to a XmlElement
        /// </summary>
        /// <param name="doc">The XmlDocument to write to</param>
        /// <param name="id">Event ID</param>
        /// <returns>An XmlElement containing the event data</returns>
        public abstract XmlElement Write(XmlDocument doc, int id);
        /// <summary>
        /// Executes the event
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Method to parse a string to a Vector2. 
        /// </summary>
        /// <param name="text">String with format: "0 0"</param>
        /// <returns>The Vector2</returns>
        protected static Vector2 ParseVector2(string text)
        {
            int x = int.Parse(text.Substring(0, text.IndexOf(' ')));
            int y = int.Parse(text.Substring(text.IndexOf(' ') + 1));

            return new Vector2(x, y);
        }   
    }
}
