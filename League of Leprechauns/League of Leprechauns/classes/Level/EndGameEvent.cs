using System;
using System.Xml;

namespace LoL
{
    class EndGameEvent : LevelEvent
    {
        public EndGameEvent(XmlNode node)
            : base(node)
        { }
        protected override void Read(System.Xml.XmlNode node)
        {
            throw new NotImplementedException();
        }

        public override XmlElement Write(XmlDocument doc, int id)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
