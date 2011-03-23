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
        }

        internal virtual void HandleCollision(AbilityObject abilityObject, Collision collision) 
        {
            abilityObject.Delete();
        }
    }
}