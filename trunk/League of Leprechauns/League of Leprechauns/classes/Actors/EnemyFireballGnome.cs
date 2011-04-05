﻿using Microsoft.Xna.Framework;
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


            animation.AddAnimation(AnimationConstants.WALKING, 41, 90, 145, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 386, 85, 145, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 90, 145, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 41, 90, 145, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 386, 85, 145, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);

            Abilities.Add(new ShootAbility(this, Settings.FIREBALL_COOLDOWN, Settings.FIREBALL_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/flameAnimation"), 45, 86, 55, 3));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

           
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
