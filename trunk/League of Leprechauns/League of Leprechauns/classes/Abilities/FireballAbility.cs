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
            this.abilityLifeTime = Settings.FIREBALL_LIFETIME;
            this.damagePoints = Settings.FIREBALL_DAMAGE;
        }

        protected override void InstanciateAbilityObject()
        {
            Texture2D abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/flameAnimation");
            

            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width / 6, abilityTexture.Height / 6), abilityLifeTime, abilityTexture, 8f, owner.FaceDirection, damagePoints, new Vector2(25,25));
            abilityObject.AddAnimation(AnimationConstants.ATTACKING, 45, 86, 55, 3);
            abilityObject.CollisionOccurred += new Attack(HandleCollision);

                 

       }

        
    }
}
