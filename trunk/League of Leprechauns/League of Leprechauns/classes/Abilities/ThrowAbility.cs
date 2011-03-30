using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class ThrowAbility : Ability
    {
        public ThrowAbility(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.abilityLifeTime = 2000;
            this.damagePoints = 10;
        }

        protected override void InstanciateAbilityObject()
        {
            Texture2D abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/bucketThrow");

            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width / 6, abilityTexture.Height / 6), abilityLifeTime, abilityTexture, 10f, owner.FaceDirection, damagePoints, new Vector2(25,25));
            abilityObject.AddAnimation(AnimationConstants.ATTACKING, 43, 56, 57, 6);
            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }

        
    }
}
