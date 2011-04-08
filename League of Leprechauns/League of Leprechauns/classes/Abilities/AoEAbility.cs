using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of an AOE ability.
    /// </summary>
    class AoEAblity : Ability
    {
        /// <summary>
        /// Instanciates a new AOE ability.
        /// </summary>
        public AoEAblity(Character owner, int cooldownTime, int damagePoints, Texture2D abilityTexture)
            : base(owner, cooldownTime, damagePoints)
        {            
            this.abilityTexture = abilityTexture;
        }

        /// <summary>
        /// Instanciates the associated ability object.
        /// </summary>
        protected override void InstanciateAbilityObject()
        {
            owner.UnSuspend();                                  
            abilityObject = new AbilityObject( new Vector2(owner.CurrentPosition.X+owner.BoundingRectangle.Width/2 -abilityTexture.Width/2, owner.CurrentPosition.Y+owner.BoundingRectangle.Height-abilityTexture.Height), abilityLifeTime, abilityTexture, 0, owner.FaceDirection, damagePoints);
                                          abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }


        /// <summary>
        /// Overriden in regards to the specificity of the area of effect.
        /// </summary>
        public override void PerformAttack()
        {
            abilitySuccessfull = false;

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
                abilitySuccessfull = true;
            }
        }


     
    }
}
