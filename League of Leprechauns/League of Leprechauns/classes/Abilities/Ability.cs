﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class Ability
    {
        protected Character owner;
        protected int abilityLifeTime;
        internal Timer abilityCooldownTimer;
        internal bool abilityReady;
        internal int damagePoints;
        internal Texture2D abilityTexture;

        public Ability(Character owner, int cooldownTime, int damagePoints)
        {
            this.abilityLifeTime = Settings.DEFAULT_ABILITY_LIFETIME;
            this.owner = owner;
            this.damagePoints = damagePoints;
            abilityCooldownTimer = new Timer(cooldownTime);
            abilityCooldownTimer.TimeEndedEvent += new TimerDelegate(CooldownEnded);
            abilityReady = true;
            
        }

        internal void CooldownEnded()
        {
            abilityReady = true;
        }

        public virtual void PerformAttack()
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
            if (collision.CollidingActor is Platform)
                abilityObject.Delete();

            if (collision.CollidingActor is HostileNPC && !(owner is HostileNPC))
            {
                ((Character)collision.CollidingActor).TakeDamage(abilityObject.DamagePoints);
                abilityObject.Delete();

            }
            else if (collision.CollidingActor is PlayerCharacter && !(owner is PlayerCharacter))
            {
                ((Character)collision.CollidingActor).TakeDamage(abilityObject.DamagePoints);
                abilityObject.Delete();

            }

            
        }
    }
}