using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class AbilityObject : NonLivingObject
    {
        private int baseDamagePoints;
        Character performer;

        public AbilityObject(Character performer, Vector2 startPosition) : base(startPosition)
        {
            this.performer = performer;
        }

        public override void HandleCollision(Collision collision)
        {
            if ((performer is PlayerCharacter && collision.getCollidingActor() is PlayerCharacter)
               ||(performer is HostileNPC && collision.getCollidingActor() is HostileNPC))
                return;

            if (performer is Character)
            {
                
                PerformAttack((Character)collision.getCollidingActor());
            }
        }

        protected virtual void PerformAttack(Character victim)
        {
            
        }
    }
}
