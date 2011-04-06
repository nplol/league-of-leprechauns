using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoL
{

    /// <summary>
    /// Class describing the actions of the evil gnomeking Nacklebiddle.
    /// </summary>
    class Nacklebiddle : HostileNPC
    {
        private int faceDir = 1;
        private Bar hpBar;
        private bool superAttack = false;
        private Texture2D avatarTexture;
                
        public Nacklebiddle(Vector2 startPosition)
            : base(startPosition)
        {
            CharacterLevel = 1;
            totalHealthPoints = Settings.NACKLEBIDDLE_HEALTH;
            healthPoints = Settings.NACKLEBIDDLE_HEALTH;
            jumpSpeed = Settings.NACKLEBIDDLE_JUMPFORCE;

            Abilities.Add(new ShootAbility(this, Settings.NACKLEBIDDLE_ICEFLAME_COOLDOWN, Settings.NACKLEBIDDLE_ICEFLAME_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/iceFlameAnimation"), 45, 86, 55, 3));
            Abilities.Add(new HitAbility(this, Settings.NACKLEBIDDLE_HIT_COOLDOWN, Settings.NACKLEBIDDLE_HIT_DAMAGE));
            Abilities.Add(new AoEAblity(this, Settings.NACKLEBIDDLE_AOE_COOLDOWN, Settings.NACKLEBIDDLE_AOE_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/BossAOE")));

            hpBar = new Bar(100, 15, new Vector2(30, 240));
            avatarTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Enemies/nacklebiddleAvatar");
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
            else if (Math.Floor(gameTime.TotalGameTime.TotalSeconds) % 12 == 8)
            {

                this.AddForce(new Vector2(12 * faceDir, 0));
                PerformAbility(AbilityNumber.FIRST);
            }
            else if (Math.Floor(gameTime.TotalGameTime.TotalSeconds) % 5 == 1)
            {
                Jump();
                PerformAbility(AbilityNumber.FIRST);          
            }
                      
            else if (((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 150) || ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) < -150))
            {
                base.Move(this.faceDirection);
            }

            else if (((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) < 40) && faceDirection == Direction.RIGHT )
            {
                base.Move(Direction.LEFT);
            }
            else if (((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 10) && faceDirection == Direction.LEFT)
            {
                base.Move(Direction.RIGHT);
            }
            else
            {
                        PerformAbility(AbilityNumber.SECOND);
            }
           animation.Update(gameTime);
        }


        public override void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            hpBar.Draw(spriteBatch, HUD.CalculatePercent(totalHealthPoints, healthPoints));
            spriteBatch.Draw(avatarTexture, new Vector2(30, 150), Color.White);
            base.Draw(spriteBatch, camera);
        }

        protected override void InitializeAnimation()
        {
            animation.AddAnimation(AnimationConstants.WALKING, 34, 93, 175, 2);
            animation.AddAnimation(AnimationConstants.JUMPING, 34, 93, 175, 2);
            animation.AddAnimation(AnimationConstants.STILL, 34, 93, 175, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 449, 100, 175, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 236, 93, 175, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);
        }
    }
}
