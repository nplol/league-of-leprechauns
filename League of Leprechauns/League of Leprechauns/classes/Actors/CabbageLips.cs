using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class CabbageLips : PlayerCharacter
    {
        public CabbageLips(Vector2 startPosition, int level, int totalHealth, int attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed) 
        {
 
        }


        const int RUNNING_AND_STILL_FRAME_WIDTH = 100;
        const int FRAME_HEIGHT = 140;
        const int END_OF_RUNNING_FRAMES = 300;
        const int START_OF_JUMP_FRAME = 300;
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            

            if (isJumping())
            {
                jumpingFrame();
            }
            else if (CurrentSpeed.X != 0)
            {
                nextRunningFrame();
            }
            else
            {
                Rectangle stillFrame = new Rectangle(0, 0, RUNNING_AND_STILL_FRAME_WIDTH, FRAME_HEIGHT);
                setFrame(stillFrame);
            }
        }

        private void nextRunningFrame(){
            if (timeForNextFrame())
            {
                timeSinceLastFrame = 0;
                Rectangle oldFrame = getFrame();
                int startOfNextFrame = (oldFrame.Left + RUNNING_AND_STILL_FRAME_WIDTH) % END_OF_RUNNING_FRAMES;
                Rectangle nextFrame = new Rectangle(startOfNextFrame, 0, RUNNING_AND_STILL_FRAME_WIDTH, FRAME_HEIGHT);
                setFrame(nextFrame);
            }
        }

        private void jumpingFrame()
        {
            Rectangle jumpFrame = new Rectangle(START_OF_JUMP_FRAME, 0, RUNNING_AND_STILL_FRAME_WIDTH, FRAME_HEIGHT);
            setFrame(jumpFrame);
        }

        public override void move()
        {

        }


        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager theContentManager, string theAssetName)
        {
            base.LoadContent(theContentManager, theAssetName);
            Rectangle newFrame = new Rectangle(0,0, 100, 140);
            setFrame(newFrame);

        }

        public override void PerformAbility(AbilityNumber abilityNumber)
        {
            switch (abilityNumber)
            {
                case AbilityNumber.FIRST:
                    break;
                case AbilityNumber.SECOND:
                    break;
                case AbilityNumber.THIRD:
                    break;
                case AbilityNumber.FOURTH:
                    break;
                default:
                    break;
            }
        }
    }
}
