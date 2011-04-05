using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace LoL
{
    class AoEAblity : Ability
    {
        public AoEAblity(Character owner, int cooldownTime, Texture2D abilityTexture)
            : base(owner, cooldownTime)
        {
            this.damagePoints = Settings.AOE_DAMAGE;
            this.abilityTexture = abilityTexture;
          
        }

        protected override void InstanciateAbilityObject()
        {
           
            owner.UnSuspend();
                                  

            AbilityObject abilityObject = new AbilityObject( new Vector2(owner.CurrentPosition.X+owner.BoundingRectangle.Width/2 -abilityTexture.Width/2, owner.CurrentPosition.Y+owner.BoundingRectangle.Height-abilityTexture.Height), abilityLifeTime, abilityTexture, 0, owner.FaceDirection, damagePoints);
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


     
    }
}
