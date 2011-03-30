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
            Texture2D abilityTexture = new Texture2D(GlobalVariables.GraphicsDevice, 40, 30);
            FillTexture(abilityTexture);

            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width, abilityTexture.Height), abilityLifeTime, abilityTexture, 0f, owner.FaceDirection, damagepoints);

            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }

        /// <summary>
        /// Debug method to show where the attack is
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
