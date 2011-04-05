using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class ShootAbility : Ability
    {

        private int numberOfAnimationFrames;
        private int animationStartHeight;
        private int animationWidth;
        private int animationHeight;

        public ShootAbility(Character owner, int cooldownTime, int damage, Texture2D abilityTexture, int animationStartHeight, int animationWidth, int animationHeight, int numberOfAnimationFrames)
            : base(owner, cooldownTime)
        {
            this.abilityLifeTime = Settings.FIREBALL_LIFETIME;
            this.damagePoints = damage;

            #region AnimationValues
            this.abilityTexture = abilityTexture;
            this.numberOfAnimationFrames = numberOfAnimationFrames;
            this.animationStartHeight = animationStartHeight;
            this.animationWidth = animationWidth;
            this.animationHeight = animationHeight;
            #endregion

        }

        protected override void InstanciateAbilityObject()
        {

            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width / numberOfAnimationFrames, 0), abilityLifeTime, abilityTexture, Settings.SHOOT_SPEED, owner.FaceDirection, damagePoints);
            abilityObject.AddAnimation(AnimationConstants.ATTACKING, animationStartHeight, animationWidth, animationHeight, numberOfAnimationFrames);
            abilityObject.CollisionOccurred += new Attack(HandleCollision);

            
        }


    }
}
