using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL.Content
{
    /// <summary>
    /// Struct that describes level event. A level event consists of a ActorType and a spawn position.
    /// </summary>
    public struct LevelEvent
    {
        string actorType;
        Vector2 position;

        public LevelEvent(string actorType, Vector2 position)
        {
            this.position = position;
            this.actorType = actorType;
        }

        public string ActorType 
        { 
            get { return this.actorType; }
            set { this.actorType = value; } 
        }
        public Vector2 Position 
        { 
            get { return this.position; } 
            set { this.position = value; } 
        }
    }
}
