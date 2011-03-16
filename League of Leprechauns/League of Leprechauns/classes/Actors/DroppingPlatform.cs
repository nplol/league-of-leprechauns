using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class DroppingPlatform : Platform
    {
        public DroppingPlatform(Vector2 startPosition, float dropSpeed, int timeLimitInSeconds) : base(startPosition)
        {
            this.startPosition = startPosition;
            this.dropSpeed = dropSpeed;
            this.timeLimit = timeLimitInSeconds * 1000;
        }

        private Vector2 startPosition;
        private float dropSpeed;
        private int activationTime;
        private int timeLimit;

        private Boolean activated;

        public void activate(GameTime gameTime)
        {
            if (activated)
            {
                return;
            }

            activated = true;
            activationTime = (int) gameTime.TotalGameTime.TotalMilliseconds;

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
            return (activated && gameTime.TotalGameTime.TotalMilliseconds 
                - activationTime > timeLimit);
        }

        private void startDropping()
        {
            CurrentPosition += new Vector2(0, dropSpeed);
        }
        
    }
}
