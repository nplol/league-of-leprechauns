
﻿using System;
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
            animation.AddAnimation(AnimationConstants.ATTACKING, 400, 112, 152, 5);
            animation.AddAnimation(AnimationConstants.DUCKING, 600, 65, 40, 1); 
            animation.SetCurrentAnimation(AnimationConstants.STILL);


            //TEMP CODE. TODO: Decide where to add abilites
            Abilities.Add(new ThrowAbility(this, Settings.ABILTIY_THROW_COOLDOWN));

            animation.AnimationDone += new AnimationDone(HandleAnimationDone);

            //TODO: want to change inputhandler a bit. Preffered behavior:
            //Abilites.Add(new HitAbility(this, 1000));
            //InputManager.Bind(PlayerIndex.One, Buttons.Y, Attack);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Attacking)
            {
                animation.SetCurrentAnimation(AnimationConstants.ATTACKING);
            }
            else if (Jumping)
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
                    this.Abilities[0].PerformAttack();
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

        public void HandleAnimationDone()
        {
            //if(!Attacking)
            //    return;

            //Attacking = false;
            //this.Abilities[0].PerformAttack();
        }
    }
}