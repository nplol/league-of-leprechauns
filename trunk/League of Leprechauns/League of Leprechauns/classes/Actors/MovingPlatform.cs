using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class MovingPlatform : NonLivingObject
    {
        public MovingPlatform(Vector2 startPosition, Vector2 speed, Vector2 lapDistance) : base(startPosition) 
        {
            this.startPosition = startPosition;
            this.Speed = speed;
            LapDistance = lapDistance;
        }

        public Vector2 Speed
        {
            get;
            set;
        }

        public Vector2 LapDistance
        {
            get;
            set;
        }

        private Vector2 startPosition;

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

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
