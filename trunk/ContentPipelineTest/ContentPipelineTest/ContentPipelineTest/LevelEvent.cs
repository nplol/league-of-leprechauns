using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ContentPipelineTest
{
    public struct LevelEvent
    {
        string actorType;
        Vector2 position;
        //Vector2 scale;

        public LevelEvent(string actorType, Vector2 position)
        {
            this.position = position;
            this.actorType = actorType;
        }

        public string ActorType { get { return this.actorType; } set { this.actorType = value; } }
        public Vector2 Position { get { return this.position; } set { this.position = value; } }
    }
}
