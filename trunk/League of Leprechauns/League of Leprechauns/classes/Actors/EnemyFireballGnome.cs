using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoL
{

    /// <summary>
    /// Class describing the behaviour of fireball gnomes.
    /// </summary>
    class EnemyFireballGnome : Gnome
    {
        /// <summary>
        /// Instanciates a new fireball gnome.
        /// </summary>
        /// <param name="startPosition"></param>
        public EnemyFireballGnome(Vector2 startPosition)
            : base(startPosition)
        {
            totalHealthPoints = Settings.GNOME_RANGED_HEALTH;
            healthPoints = Settings.GNOME_RANGED_HEALTH;
            PlayerDistance = Settings.GNOME_RANGED_PLAYERDISTANCE;

            Abilities.Add(new RangedAbility(this, Settings.GNOME_FIREBALL_COOLDOWN, Settings.GNOME_FIREBALL_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/flameAnimation"), 45, 86, 55, 3));
        }

        /// <summary>
        /// Class specific animation initialization.
        /// </summary>
        protected override void InitializeAnimation()
        {
            animation.AddAnimation(AnimationConstants.WALKING, 41, 90, 145, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 386, 85, 145, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 90, 145, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 41, 90, 145, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 386, 85, 145, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);
        }
        
    }
}
