using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LoL.classes;

namespace LoL
{
    class CabbageLips : PlayerCharacter
    {
        public CabbageLips(Vector2 startPosition, int level, Vector2 startSpeed, int totalHealth, Vector2 attackSpeed, int jumping)
            : base(startPosition, level, startSpeed, totalHealth, attackSpeed, jumping) 
        {
 
        }

        public override void Update(GameTime gameTime)
        {
            List<Collision> collisions = CollisionDetector.detectCollision(this);
            foreach (Collision collision in collisions)
            {
                handleCollision(collision);
            }
            base.Update(gameTime);
        }

        public override void move()
        {
            
        }

        private void handleCollision(Collision collision)
        {
            CollisionType collisionDirection = collision.getDirection();
            if (collisionDirection == CollisionType.collideSide)
            {
                MovementSpeedX = 0;
            }
            else if (collisionDirection == CollisionType.collideBottom)
            {
                MovementSpeedY = 0;
            }
            else if (collisionDirection == CollisionType.collideTop)
            {
                MovementSpeedY *= -1;
            }
        }

    }
}
