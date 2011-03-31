using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class HitAbility : Ability
    {

        public HitAbility(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.damagePoints = Settings.HIT_DAMAGE;
            
        }

        protected override void InstanciateAbilityObject()
        {
            Texture2D abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/HitSlash");
            float abilitySpeed = 8f;
            Vector2 hitbox = new Vector2(75, 10);
          
            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width,-abilityTexture.Height/2) , 
                                                            abilityLifeTime, 
                                                            abilityTexture, 
                                                            abilitySpeed, 
                                                            owner.FaceDirection, 
                                                            damagePoints, 
                                                            hitbox);


            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }

      

        
    }
}
