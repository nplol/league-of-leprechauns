using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoL
{

    /// <summary>
    /// Class describing the actions of the evil gnomeking Nacklebiddle.
    /// </summary>
    class Nacklebiddle : HostileNPC, IKeepActive
    {
        private int faceDir = 1;

        private bool superAttack = false;
                
        public Nacklebiddle(Vector2 startPosition, int level, int totalHealth, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed)
        {


            animation.AddAnimation(AnimationConstants.WALKING, 34, 93, 175, 2);
            animation.AddAnimation(AnimationConstants.JUMPING, 34, 93, 175, 2);
            animation.AddAnimation(AnimationConstants.STILL, 34, 93, 175, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 449, 100, 175, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 236, 93, 175, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);

            
            Abilities.Add(new ShootAbility(this, Settings.ICEFLAME_COOLDOWN, Settings.ICEFLAME_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/iceFlameAnimation"), 45, 86, 55, 3));
            Abilities.Add(new HitAbility(this, Settings.HIT_COOLDOWN));
            Abilities.Add(new AoEAblity(this, Settings.HIT_COOLDOWN));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            nearestPlayer = base.NearestPlayer;
            if ( faceDirection == Direction.LEFT ) faceDir = -1;
            else if ( faceDirection == Direction.RIGHT ) faceDir = 1;

          
            if (Math.Floor(gameTime.TotalGameTime.TotalSeconds) % 12 == 7 )
            {

                 this.AddForce(new Vector2(0, -1.1f));
                 Jumping = true;
                 superAttack = true;
                 PerformAbility(AbilityNumber.FIRST);
              
            }
            else if (Jumping && superAttack)
            {
                
               PerformAbility(AbilityNumber.THIRD);
               Jumping = false;
               superAttack = false;
            }


            else if (Math.Floor(gameTime.TotalGameTime.TotalSeconds) % 6 == 3)
            {

                Jump();
                PerformAbility(AbilityNumber.FIRST);
                       
            }

            else if (Math.Floor(gameTime.TotalGameTime.TotalSeconds) % 12 == 4)
            {

                this.AddForce(new Vector2(12*faceDir, 0));
                PerformAbility(AbilityNumber.FIRST);

            }

            else if (((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 150) || ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) < -150))
            {
                base.Move(this.faceDirection);

            }

            else
            {
                        PerformAbility(AbilityNumber.SECOND);
                //PerformAbility(AbilityNumber.SECOND);
                //PerformAbility(AbilityNumber.THIRD);
                //PerformAbility(AbilityNumber.FOURTH);
                //  Jump();


            }
           animation.Update(gameTime);
        }



    }
}
