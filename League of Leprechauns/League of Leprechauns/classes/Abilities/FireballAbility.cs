using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class FireballAbility : Ability
    {

        
        public FireballAbility(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.abilityLifeTime = Settings.SHOOT_LIFETIME;
            this.damagePoints = Settings.FIREBALL_DAMAGE;
            abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/flameAnimation");
        }

        protected override void InstanciateAbilityObject()
        {
            
            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width / 6, 0 ), abilityLifeTime, abilityTexture, 8f, owner.FaceDirection, damagePoints);
            abilityObject.AddAnimation(AnimationConstants.ATTACKING, 45, 86, 55, 3);
            abilityObject.CollisionOccurred += new Attack(HandleCollision);

                 

       }

        
    }
}
