using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace LoL
{
    class AoEAblity : Ability
    {
        public AoEAblity(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.abilityLifeTime = 100;
            this.damagePoints = Settings.AOE_DAMAGE;
            
            abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/AOEAbility");
          
        }

        protected override void InstanciateAbilityObject()
        {
           
            

            owner.UnSuspend();
                                   

            AbilityObject abilityObject = new AbilityObject( new Vector2(owner.CurrentPosition.X-120, owner.CurrentPosition.Y+115), abilityLifeTime, abilityTexture, 0, owner.FaceDirection, damagePoints);
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
