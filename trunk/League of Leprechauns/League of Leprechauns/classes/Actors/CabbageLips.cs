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

            animation.AddAnimation(AnimationConstants.WALKING, 15, 81, 135, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 180, 87, 137, 1);
            animation.AddAnimation(AnimationConstants.STILL, 15, 81, 135, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            if (IsJumping())
            {
                animation.SetCurrentAnimation(AnimationConstants.JUMPING);
            }
            else if (CurrentSpeed.X != 0)
            {
                animation.SetCurrentAnimation(AnimationConstants.WALKING);
            }
            else
            {
                animation.SetCurrentAnimation(AnimationConstants.STILL);
            }
        }

        public override void Move()
        {

        }


        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager theContentManager, string theAssetName)
        {
            base.LoadContent(theContentManager, theAssetName);
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
