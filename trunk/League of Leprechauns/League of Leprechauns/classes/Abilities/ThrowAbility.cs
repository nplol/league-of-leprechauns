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
            this.abilityLifeTime = Settings.THROW_LIFETIME;
            this.damagePoints = Settings.THROW_DAMAGE;
        }

        protected override void InstanciateAbilityObject()
        {
            Texture2D abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/bucketThrow");
            float abilitySpeed = 10f;
            Vector2 hitbox = new Vector2(25, 25);
            int frames = 6;
            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width/frames , -(abilityTexture.Height / 3)), 
                                                            abilityLifeTime, 
                                                            abilityTexture, 
                                                            abilitySpeed, 
                                                            owner.FaceDirection, 
                                                            damagePoints, 
                                                            hitbox);
            
            abilityObject.AddAnimation(AnimationConstants.ATTACKING, 43, 56, 57, 6);
            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }

        
    }
}
