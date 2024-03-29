﻿using System.Xml;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Level event used for spawning actors.
    /// </summary>
    public class ActorSpawnEvent : LevelEvent
    { 
        private string actorType;
        private string texture;
        private Vector2 position;

        public string Texture
        {
            get { return texture; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public string ActorType
        {
            get { return actorType; }
        }

        public ActorSpawnEvent(XmlNode node) : base(node) { }

        public ActorSpawnEvent(string actorType, string texture, Vector2 position)
        {
            this.actorType = actorType;
            this.texture = texture;
            this.position = position;
        }

        protected override void Read(XmlNode node)
        {
            this.eventID = int.Parse(node["eventID"].InnerText);
            this.actorType = node["actorType"].InnerText;
            this.texture = node["texture"].InnerText;
            this.position = ParseVector2(node["position"].InnerText);
        }

        public override XmlElement Write(XmlDocument doc, int id)
        {
            XmlElement eventElement = doc.CreateElement("event");

            XmlElement element = doc.CreateElement("eventType");
            element.InnerText = "ActorSpawn";
            eventElement.AppendChild(element);

            element = doc.CreateElement("eventID");
            element.InnerText = id.ToString();
            eventElement.AppendChild(element);

            element = doc.CreateElement("actorType");
            element.InnerText = actorType;
            eventElement.AppendChild(element);

            element = doc.CreateElement("texture");
            element.InnerText = texture;
            eventElement.AppendChild(element);

            element = doc.CreateElement("position");
            element.InnerText = position.X.ToString() + " " + position.Y.ToString();
            eventElement.AppendChild(element);

            return eventElement;
        }

        /// <summary>
        /// Executes the ActorSpawnEvent. Instanciates a new Actor.
        /// </summary>
        public override void Execute()
        {
            Actor actor = GlobalVariables.ActorFactory.CreateActor(actorType, position, texture);
            actor.actorID = eventID;
            ActorManager.addActor(actor);
        }
    }
}