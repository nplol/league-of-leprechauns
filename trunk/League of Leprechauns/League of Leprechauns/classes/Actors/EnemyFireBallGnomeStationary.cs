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
            Abilities.Add(new ShootAbility(this, Settings.GNOME_FIREBALL_COOLDOWN, Settings.GNOME_FIREBALL_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/flameAnimation"), 45, 86, 55, 3));
        }

        protected override void InitializeAnimation()
        {
            animation.AddAnimation(AnimationConstants.WALKING, 41, 90, 145, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 386, 85, 145, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 90, 145, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 41, 90, 145, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 386, 85, 145, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }

        public override void Update(GameTime gameTime)
        {
           // if (isSuspended) return;
            base.Update(gameTime);
                                        
            PerformAbility(AbilityNumber.FIRST);

            animation.Update(gameTime);
        }

    }
}
