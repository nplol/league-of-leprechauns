using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    abstract class Platform : NonLivingObject
    {
        private Microsoft.Xna.Framework.Vector2 startPosition;

        public Platform(Vector2 startPosition) : base(startPosition)
        {
            this.startPosition = startPosition;
        }
    }
}
