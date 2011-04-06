using Microsoft.Xna.Framework;


namespace LoL
{

    /// <summary>
    /// Class describing the behaviour of melee gnomes.
    /// </summary>
    class EnemyMeleeGnome : Gnome
    {
        /// <summary>
        /// Instanciates a new meele gnome.
        /// </summary>
        /// <param name="startPosition"></param>
        public EnemyMeleeGnome(Vector2 startPosition)
            : base(startPosition)
        {
            totalHealthPoints = Settings.GNOME_MELEE_HEALTH;
            healthPoints = Settings.GNOME_MELEE_HEALTH;
            PlayerDistance = Settings.GNOME_MELEE_PLAYERDISTANCE;

            Abilities.Add(new MeleeAbility(this, Settings.GNOME_HIT_COOLDOWN, Settings.GNOME_HIT_DAMAGE));
        }

        /// <summary>
        /// Class specific animation initialization.
        /// </summary>
        protected override void InitializeAnimation()
        {
            animation.AddAnimation(AnimationConstants.WALKING, 41, 92, 148, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 215, 90, 148, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 90, 148, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 41, 90, 148, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 386, 85, 148, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);
        }
    }
}
