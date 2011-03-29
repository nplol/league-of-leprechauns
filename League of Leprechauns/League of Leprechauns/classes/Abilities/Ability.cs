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

        public Ability(Character owner, int cooldownTime)
        {
            this.owner = owner;
            abilityCooldownTimer = new Timer(cooldownTime);
            abilityCooldownTimer.TimeEndedEvent += new TimerDelegate(CooldownEnded);
            abilityReady = true;
        }

        private void CooldownEnded()
        {
            abilityReady = true;
        }

        public void PerformAttack()
        {
            if (abilityReady)
            {
                InstanciateAbilityObject();
                abilityReady = false;
                abilityCooldownTimer.Start();
            }
        }

        protected virtual void InstanciateAbilityObject()
        {
            owner.Attacking = true;
        }

        internal virtual void HandleCollision(AbilityObject abilityObject, Collision collision) 
        {
            abilityObject.Delete();
        }

        public Vector2 GetAbilityPosition(int abilityWidth, int abilityHeight)
        {
            Vector2 position = new Vector2();
             if(owner.FaceDirection == Direction.LEFT)
                position.X = -abilityWidth;
            else if(owner.FaceDirection == Direction.RIGHT)
                position.X = owner.BoundingRectangle.Width;


            position.X += owner.CurrentPosition.X;
            position.Y = owner.CurrentPosition.Y + owner.BoundingRectangle.Height / 2 - 30;

            return position;
        }
    }
}