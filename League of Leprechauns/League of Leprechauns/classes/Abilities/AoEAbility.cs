using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class AoEAblity : Ability
    {
        public AoEAblity(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.abilityLifeTime = 1;
            this.damagePoints = Settings.AOE_DAMAGE;
        }

        protected override void InstanciateAbilityObject()
        {
           
            

            owner.UnSuspend();

            Texture2D abilityTexture = new Texture2D(GlobalVariables.GraphicsDevice, 350, 30);
            FillTexture(abilityTexture);

            AbilityObject abilityObject = new AbilityObject( new Vector2(owner.CurrentPosition.X-120, owner.CurrentPosition.Y+120), abilityLifeTime, abilityTexture, 0, owner.FaceDirection, damagePoints, new Vector2(350, 30));
            abilityObject.CollisionOccurred += new Attack(HandleCollision);

        }


        public override void PerformAttack()
        {
            if (abilityReady && owner.Jumping)
            {
                abilityCooldownTimer.Start();
                abilityReady = false;
                owner.Attacking = true;
                owner.Suspend();
                owner.AddForce(new Vector2(0, 35));
                Timer timer = new Timer(200);
                timer.TimeEndedEvent += new TimerDelegate(InstanciateAbilityObject);
                timer.Start();
            }
        }


        // Testcode to see where the Aoe is
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
