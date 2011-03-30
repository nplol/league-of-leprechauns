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


            animation.AddAnimation(AnimationConstants.WALKING, 41, 90, 144, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 215, 88, 148, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 90, 144, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 42, 90, 144, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 386, 85, 147, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);

            Abilities.Add(new FireballAbility(this, Settings.FIREBALL_COOLDOWN));

        }

        public override void Update(GameTime gameTime)
        {
            if (isSuspended) return;
            base.Update(gameTime);

            Actor nearestPlayer = base.getNearestPlayer();


           
            if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 400)
            {
                base.Move(this.faceDirection);
          
            }
            else if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) < -400)
            {
                base.Move(this.faceDirection);
             
            
            }

            PerformAbility(AbilityNumber.FIRST);

            animation.Update(gameTime);
        }


        
    }
}