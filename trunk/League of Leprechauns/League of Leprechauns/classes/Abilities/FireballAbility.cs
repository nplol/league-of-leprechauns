using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class FireballAbility : Ability
    {
        public FireballAbility(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.abilityLifeTime = 2000;
        }

        protected override void InstanciateAbilityObject()
        {
            Texture2D abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/flameAnimation");
            

            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width / 6, abilityTexture.Height / 6), abilityLifeTime, abilityTexture, 8f, owner.FaceDirection);
            abilityObject.AddAnimation(AnimationConstants.ATTACKING, 45, 86, 55, 3);
            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }

        internal override void HandleCollision(AbilityObject abilityObject, Collision collision)
        {
            if (collision.getCollidingActor() is Platform)
                abilityObject.Delete();

            if (collision.getCollidingActor() is PlayerCharacter && collision.getCollidingActor() != owner)
            {
                ((Character)collision.getCollidingActor()).TakeDamage(10);
                base.HandleCollision(abilityObject, collision);
            }
        }
    }
}
