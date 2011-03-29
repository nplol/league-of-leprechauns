﻿using System;
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
            animation.AddAnimation(AnimationConstants.ATTACKING, 340, 80, 136, 1);
            animation.AddAnimation(AnimationConstants.DUCKING, 500, 60, 50, 0);
            animation.SetCurrentAnimation(AnimationConstants.STILL);

            Abilities.Add(new HitAbility(this, Settings.ABILITY_HIT_COOLDOWN));
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);
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

        public override void PerformAbility(AbilityNumber abilityNumber)
        {
            switch (abilityNumber)
            {
                case AbilityNumber.FIRST:
                    Abilities[0].PerformAttack();
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

        public void HandleAnimationDone()
        {
            if (!Attacking)
                return;

            Attacking = false;
            this.Abilities[0].PerformAttack();
        }
    }
}