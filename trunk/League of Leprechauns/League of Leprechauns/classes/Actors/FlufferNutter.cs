using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class FlufferNutter : PlayerCharacter
    {
        public FlufferNutter(Vector2 startPosition, int level, int totalHealth, int attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed)
        {

            animation.AddAnimation(AnimationConstants.WALKING, 30, 64, 145, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 215, 67, 147, 1);
            animation.AddAnimation(AnimationConstants.STILL, 30, 64, 145, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);


            //TEMP CODE. TODO: Decide where to add abilites
            Abilities.Add(new HitAbility(this, Settings.ABILITY_HIT_COOLDOWN));
            Abilities.Add(new ThrowAbility(this, Settings.ABILTIY_THROW_COOLDOWN));

            //TODO: want to change inputhandler a bit. Preffered behavior:
            //Abilites.Add(new HitAbility(this, 1000));
            //InputManager.Bind(PlayerIndex.One, Buttons.Y, Attack);
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

        //TODO: Remove?
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

        //Attack should maybe take in a enum value describing witch attack to execute?
        public void Attack(AbilityNumber abilityNumber)
        {
            this.Abilities[(int)abilityNumber].PerformAttack();
        }
    }
}
