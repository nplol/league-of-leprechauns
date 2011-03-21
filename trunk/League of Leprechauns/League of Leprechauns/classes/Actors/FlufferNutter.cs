using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class FlufferNutter : PlayerCharacter
    {
        public FlufferNutter(Vector2 startPosition, int level, int totalHealth, Vector2 attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (isJumping())
            {
                Rectangle jumpingFrame = new Rectangle((62*3), 0, 63, 145);
                setFrame(jumpingFrame);
            }
            else if (CurrentSpeed.X != 0)
            {
                nextRunningFrame();
            }
            else
            {
                Rectangle standingFrame = new Rectangle(0, 0, 61, 145);
                setFrame(standingFrame);
            }
        }

        private void nextRunningFrame()
        {
            if (timeForNextFrame())
            {
                timeSinceLastFrame = 0;
                Rectangle oldFrame = getFrame();
                Rectangle nextFrame = new Rectangle((oldFrame.Left + 62) % (62*3), 0, 61, 145);
                setFrame(nextFrame);
            }
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager theContentManager, string theAssetName)
        {
            base.LoadContent(theContentManager, theAssetName);
            Rectangle newFrame = new Rectangle(0, 0, 59, 145);
            setFrame(newFrame);

        }
    }
}
