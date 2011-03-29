using System;
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
    class EnemyMeleeGnome : HostileNPC
    {


        public EnemyMeleeGnome(Vector2 startPosition, int level, int totalHealth, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed)
        {


            animation.AddAnimation(AnimationConstants.WALKING, 41, 92, 148, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 215, 90, 149, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 92, 148, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 41, 92, 148, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);

            Abilities.Add(new HitAbility(this, Settings.ABILITY_HIT_COOLDOWN));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Actor nearestPlayer = base.getNearestPlayer();



            if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 100)
            {
                base.Move(this.faceDirection);
                animation.SetCurrentAnimation(AnimationConstants.WALKING);
            }
            else if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) < -100)
            {
                base.Move(this.faceDirection);
                animation.SetCurrentAnimation(AnimationConstants.WALKING);
            }
            else
            {
                PerformAbility(AbilityNumber.FIRST);
                animation.SetCurrentAnimation(AnimationConstants.ATTACKING);

            }

            

            animation.Update(gameTime);
        }



    }
}
