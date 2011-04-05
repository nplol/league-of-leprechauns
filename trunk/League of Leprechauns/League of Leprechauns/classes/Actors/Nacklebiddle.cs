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


            animation.AddAnimation(AnimationConstants.WALKING, 34, 93, 175, 2);
            animation.AddAnimation(AnimationConstants.JUMPING, 34, 93, 175, 2);
            animation.AddAnimation(AnimationConstants.STILL, 34, 93, 175, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 449, 100, 175, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 236, 93, 175, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);

            //Abilities.Add(new HitAbility(this, Settings.HIT_COOLDOWN));
            Abilities.Add(new ShootAbility(this, Settings.ICEFLAME_COOLDOWN, Settings.ICEFLAME_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/iceFlameAnimation"), 45, 86, 55, 3));
            //Abilities.Add(new ThrowAbility(this, Settings.HIT_COOLDOWN));
            //Abilities.Add(new AoEAblity(this, Settings.HIT_COOLDOWN));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            nearestPlayer = base.NearestPlayer;

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
                //PerformAbility(AbilityNumber.SECOND);
                //PerformAbility(AbilityNumber.THIRD);
                //PerformAbility(AbilityNumber.FOURTH);
              //  Jump();
                

            }
           animation.Update(gameTime);
        }



    }
}
