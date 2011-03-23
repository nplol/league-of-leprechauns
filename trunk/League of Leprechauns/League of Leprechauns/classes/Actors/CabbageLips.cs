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

            animation.AddAnimation(AnimationConstants.WALKING, 12, 81, 135, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 180, 87, 137, 1);
            animation.AddAnimation(AnimationConstants.STILL, 12, 81, 135, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            if (isJumping())
            {
                animation.SetCurrentAnimation(AnimationConstants.JUMPING);
            }
            else if (CurrentSpeed.X != 0)
            {
                //nextRunningFrame();
            }
            else
            {
            //    Rectangle stillFrame = new Rectangle(0, 0, RUNNING_AND_STILL_FRAME_WIDTH, FRAME_HEIGHT);
            //    setFrame(stillFrame);
            }
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
