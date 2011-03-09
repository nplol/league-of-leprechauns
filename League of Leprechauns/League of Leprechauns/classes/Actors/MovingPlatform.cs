﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class MovingPlatform : NonLivingObject
    {
        public MovingPlatform(Vector2 startPosition) : base(startPosition) 
        {
            this.startPosition = startPosition;
        }

        public Vector2 Speed
        {
            get;
            set;
        }

        public Vector2 LapDistance
        {
            get;
        }

        private Vector2 startPosition;

        public override void Update(GameTime gametime)
        {
            if (testUpperBounds() || testLowerBounds())
                Speed *= -1;
            Position += Speed;
        }

        private Boolean testUpperBounds()
        {
            return (Position.X + Speed.X > startPosition.X + LapDistance.X) || (Position.Y + Speed.Y > startPosition.Y + LapDistance.Y);
        }

        private Boolean testLowerBounds()
        {
            return (Position.X + Speed.X < startPosition.X) || (Position.Y + Speed.Y < startPosition.Y);
        }
    }
}
