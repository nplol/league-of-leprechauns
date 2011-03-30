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

        private int damagepoints;
        

        public HitAbility(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.damagepoints = 5;
            
        }

        protected override void InstanciateAbilityObject()
        {
            Texture2D abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/HitSlash");
            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(0,-abilityTexture.Height/2) , 
                                                            abilityLifeTime, abilityTexture, 8f, owner.FaceDirection, 
                                                            damagePoints, 
                                                            new Vector2(25, 25));


            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }

        /// <summary>
        /// Debug method to show where the attack iss
        /// </summary>
        /// <param name="abilityTexture"></param>
        private void FillTexture(Texture2D abilityTexture)
        {
            Color[] data = new Color[abilityTexture.Width * abilityTexture.Height];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Red;
            }
            abilityTexture.SetData(data);

        }

        
    }
}
