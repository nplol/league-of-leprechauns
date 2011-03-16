using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL.classes.Actors
{
    class SinkablePlatform : Platform
    {
        public SinkablePlatform(Vector2 startPosition) : base(startPosition)
        {
            this.startPosition = startPosition;
        }

        private Vector2 startPosition, speed;
        private int activationTime;
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

        public void deactivate(GameTime gameTime)
        {
            if (!activated)
            {
                return;
            }
            activated = false;
            activationTime = -1; 
        }

        public override void Update(GameTime gameTime)
        {
            if (activated)
            {
                startSinking(gameTime);
            }
            base.Update(gameTime);
        }

        private void startSinking(GameTime gameTime)
        {
            float accerelation = 1.3f;
            float elapsedTimeInSeconds = ((int)gameTime.TotalGameTime.TotalMilliseconds - activationTime) / 1000;
            speed = new Vector2(0, accerelation*elapsedTimeInSeconds*elapsedTimeInSeconds);
            CurrentPosition += speed;
        }

    }
}
