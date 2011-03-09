using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL.classes.Actors
{
    class DroppingPlatform : NonLivingObject
    {
        public DroppingPlatform(Vector2 startPosition, float dropSpeed, int timeLimit) : base(startPosition)
        {
            this.startPosition = startPosition;
            this.dropSpeed = dropSpeed;
            this.timeLimit = new TimeSpan(timeLimit);
        }

        private Vector2 startPosition, position;
        private float dropSpeed;
        private GameTime activationTime;
        private TimeSpan timeLimit;

        private Boolean activated;

        public void activate(GameTime gameTime)
        {
            if (activated)
            {
                return;
            }

            activated = true;
            activationTime = gameTime;

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (timeLimitExceeded(gameTime))
            {
                startDropping();
            }
        }

        private Boolean timeLimitExceeded(GameTime gameTime)
        {
            return (activated && gameTime.ElapsedGameTime - activationTime.ElapsedGameTime > timeLimit);
        }

        private void startDropping()
        {
            position.Y -= dropSpeed;
        }
        
    }
}
