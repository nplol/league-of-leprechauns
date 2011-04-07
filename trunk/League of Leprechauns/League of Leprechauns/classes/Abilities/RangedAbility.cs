using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of a ranged ability.
    /// </summary>
    class RangedAbility : Ability
    {
        #region attributes
        private int numberOfAnimationFrames;
        private int animationStartHeight;
        private int animationWidth;
        private int animationHeight;
        #endregion

        /// <summary>
        /// Instanciates a new ranged ability, the extra parametres are for the animation.
        /// </summary>
        public RangedAbility(Character owner, int cooldownTime, int damagePoints, Texture2D abilityTexture, int animationStartHeight, int animationWidth, int animationHeight, int numberOfAnimationFrames)
            : base(owner, cooldownTime, damagePoints)
        {
            this.abilityLifeTime = Settings.SHOOT_LIFETIME;

            #region AnimationValues
            this.abilityTexture = abilityTexture;
            this.numberOfAnimationFrames = numberOfAnimationFrames;
            this.animationStartHeight = animationStartHeight;
            this.animationWidth = animationWidth;
            this.animationHeight = animationHeight;
            #endregion

        }


        /// <summary>
        /// Instanciates the associated ability object.
        /// </summary>
        protected override void InstanciateAbilityObject()
        {
            abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width / numberOfAnimationFrames, 0), abilityLifeTime, abilityTexture, Settings.SHOOT_SPEED, owner.FaceDirection, damagePoints);
                                          abilityObject.AddAnimation(AnimationConstants.ATTACKING, animationStartHeight, animationWidth, animationHeight, numberOfAnimationFrames);
                                          abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }
    }
}
