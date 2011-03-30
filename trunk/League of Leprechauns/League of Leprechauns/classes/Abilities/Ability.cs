using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class Ability
    {
        protected Character owner;
        protected int abilityLifeTime = 0;
        private Timer abilityCooldownTimer;
        private bool abilityReady;
        internal int damagePoints;

        public Ability(Character owner, int cooldownTime)
        {
            this.owner = owner;
            abilityCooldownTimer = new Timer(cooldownTime);
            abilityCooldownTimer.TimeEndedEvent += new TimerDelegate(CooldownEnded);
            abilityReady = true;
        }

        internal void CooldownEnded()
        {
            abilityReady = true;
        }

        public void PerformAttack()
        {
            if (abilityReady)
            {
                abilityCooldownTimer.Start();
                InstanciateAbilityObject();
                abilityReady = false;
                owner.Attacking = true;
                }
        }

        protected virtual void InstanciateAbilityObject()
        {
            
        }

        
        public Vector2 GetAbilityPosition(int offsetWidth, int offsetHeight)
        {
            Vector2 position = new Vector2();
            position.Y = offsetHeight;
             if(owner.FaceDirection == Direction.LEFT)
                position.X = -offsetWidth;
            else if(owner.FaceDirection == Direction.RIGHT)
                position.X = owner.BoundingRectangle.Width;


            position.X += owner.CurrentPosition.X;
            position.Y += owner.CurrentPosition.Y + (owner.BoundingRectangle.Height / 2);

            return position;
        }


        internal virtual void HandleCollision(AbilityObject abilityObject, Collision collision)
        {
            if (collision.getCollidingActor() is Platform)
                abilityObject.Delete();

            if (collision.getCollidingActor() is HostileNPC && !(owner is HostileNPC))
            {
                ((Character)collision.getCollidingActor()).TakeDamage(abilityObject.DamagePoints);
                abilityObject.Delete();

            }
            else if (collision.getCollidingActor() is PlayerCharacter && !(owner is PlayerCharacter))
            {
                ((Character)collision.getCollidingActor()).TakeDamage(abilityObject.DamagePoints);
                abilityObject.Delete();

            }

            
        }
    }
}