using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class StupidRollingHostileNPC : HostileNPC
    {
        private Direction _movementDirection;
        private Vector2 startPosition;
        private List<Actor> actorsDamageAlreadyTaken;

        public StupidRollingHostileNPC(Vector2 startPosition, int level, Vector2 startSpeed, int totalHealth, Direction movementDirection)
            : base(startPosition, level, totalHealth, 0, 0)
        {
            _movementDirection = movementDirection;
            this.startPosition = startPosition;
            actorsDamageAlreadyTaken = new List<Actor>();
        }

        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move(_movementDirection);
        }

        public override void HandleCollision(Collision collision)
        {
            base.HandleCollision(collision);
            Vector2 transVec = collision.getTranslationVector();
            Actor collidingActor = collision.getCollidingActor();
            if (collidingActor is Character)
            {
                collidingActor.AddForce(new Vector2(0, -5*Settings.GRAVITY));
                if (!actorsDamageAlreadyTaken.Contains(collidingActor))
                {
                    ((Character)collidingActor).TakeDamage(-1);
                    actorsDamageAlreadyTaken.Add(collidingActor);
                }
                
            
            }
        

        }
     
        private void turnAround()
        {
            if (_movementDirection == Direction.LEFT)
                _movementDirection = Direction.RIGHT;
            else
                _movementDirection = Direction.LEFT;
        }


        public override void PerformAbility(AbilityNumber abilityNumber)
        {
            throw new NotImplementedException();
        }
    }
}
