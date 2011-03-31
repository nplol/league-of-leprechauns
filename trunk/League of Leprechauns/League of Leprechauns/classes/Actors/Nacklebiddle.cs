using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoL
{

    /// <summary>
    /// Class describing the actions of the evil gnomeking Nacklebiddle.
    /// </summary>
    class Nacklebiddle : HostileNPC
    {
        
        public Nacklebiddle(Vector2 startPosition, int level, int totalHealth, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed)
        {


            animation.AddAnimation(AnimationConstants.WALKING, 0, 138, 171, 1);
            animation.AddAnimation(AnimationConstants.JUMPING, 0, 138, 171, 1);
            animation.AddAnimation(AnimationConstants.STILL, 0, 138, 171, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 0, 138, 171, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 0, 138, 171, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);

            Abilities.Add(new HitAbility(this, Settings.HIT_COOLDOWN));
            Abilities.Add(new FireballAbility(this, Settings.HIT_COOLDOWN));
            Abilities.Add(new ThrowAbility(this, Settings.HIT_COOLDOWN));
            Abilities.Add(new AoEAblity(this, Settings.HIT_COOLDOWN));

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
            else
            {
                PerformAbility(AbilityNumber.FIRST);
                PerformAbility(AbilityNumber.SECOND);
                PerformAbility(AbilityNumber.THIRD);
                PerformAbility(AbilityNumber.FOURTH);
                Jump();
                

            }
           animation.Update(gameTime);
        }



    }
}
