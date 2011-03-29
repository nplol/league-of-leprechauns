﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoL
{

    /// <summary>
    /// Class describing the actions of enemy NPCs.
    /// </summary>
    class EnemyFireballGnome : HostileNPC
    {


        public EnemyFireballGnome(Vector2 startPosition, int level, int totalHealth, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed)
        {
           

            animation.AddAnimation(AnimationConstants.WALKING, 41, 92, 148, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 215, 90, 149, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 92, 148, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 41, 92, 148, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);

            Abilities.Add(new FireballAbility(this, Settings.ABILITY_FIREBALL_COOLDOWN));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Actor nearestPlayer = base.getNearestPlayer();


           
            if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 400)
            {
                base.Move(this.faceDirection);
                animation.SetCurrentAnimation(AnimationConstants.WALKING);
            }
            else if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) < -400)
            {
                base.Move(this.faceDirection);
                animation.SetCurrentAnimation(AnimationConstants.WALKING);
            }
            else
            {
                animation.SetCurrentAnimation(AnimationConstants.STILL);

            }

            PerformAbility(AbilityNumber.FIRST);

            animation.Update(gameTime);
        }


        
    }
}