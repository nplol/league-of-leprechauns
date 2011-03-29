﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class ThrowAbility : Ability
    {
        public ThrowAbility(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.abilityLifeTime = 2000;
        }

        protected override void InstanciateAbilityObject()
        {
            Texture2D abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/bucketThrow");

            AnimationDefiniton animationDefinition = new AnimationDefiniton(AnimationConstants.ATTACKING, 43, 56, 57, 6);

            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width / 6, abilityTexture.Height / 6), abilityLifeTime, abilityTexture, 10f, owner.FaceDirection);
            abilityObject.AddAnimation(animationDefinition);
            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }

        internal override void HandleCollision(AbilityObject abilityObject, Collision collision)
        {
            if(collision.getCollidingActor() is Platform)
                abilityObject.Delete();
                
            if (collision.getCollidingActor() is Character && collision.getCollidingActor() != owner)
            {
                ((Character)collision.getCollidingActor()).TakeDamage(10);
                base.HandleCollision(abilityObject, collision);
            }
        }
    }
}