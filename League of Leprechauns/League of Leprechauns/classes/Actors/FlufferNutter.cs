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

        const int START_OF_JUMP_FRAME = 62 * 3;
        const int JUMP_FRAME_WIDTH = 63;
        const int RUNNING_AND_STILL_FRAME = 62;
        const int FRAME_HEIGHT = 145;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (isJumping())
            {
                Rectangle jumpingFrame = new Rectangle(START_OF_JUMP_FRAME, 0, JUMP_FRAME_WIDTH, FRAME_HEIGHT);
                setFrame(jumpingFrame);
            }
            else if (CurrentSpeed.X != 0)
            {
                nextRunningFrame();
            }
            else
            {
                Rectangle standingFrame = new Rectangle(0, 0, RUNNING_AND_STILL_FRAME, FRAME_HEIGHT);
                setFrame(standingFrame);
            }
        }

        private void nextRunningFrame()
        {
            if (timeForNextFrame())
            {
                timeSinceLastFrame = 0;
                Rectangle oldFrame = getFrame();
                int startOfNextFrame = (oldFrame.Left + RUNNING_AND_STILL_FRAME) % (RUNNING_AND_STILL_FRAME*3);
                Rectangle nextFrame = new Rectangle(startOfNextFrame, 0, RUNNING_AND_STILL_FRAME, FRAME_HEIGHT);
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
