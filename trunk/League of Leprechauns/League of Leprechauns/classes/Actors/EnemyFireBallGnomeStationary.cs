using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoL
{

    /// <summary>
    /// Class describing the actions of the Stationary fireballGnome.
    /// </summary>
    class EnemyFireballGnomeStationary : HostileNPC
    {
        public EnemyFireballGnomeStationary(Vector2 startPosition, int level, int totalHealth, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed)
        {
            animation.AddAnimation(AnimationConstants.WALKING, 41, 90, 145, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 386, 85, 148, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 90, 145, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 41, 90, 145, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 386, 85, 147, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);

            Abilities.Add(new FireballAbility(this, Settings.FIREBALL_COOLDOWN));

        }

        public override void Update(GameTime gameTime)
        {
           // if (isSuspended) return;
            base.Update(gameTime);

            Actor nearestPlayer = base.getNearestPlayer();
                                        
            PerformAbility(AbilityNumber.FIRST);

            animation.Update(gameTime);
        }

    }
}
