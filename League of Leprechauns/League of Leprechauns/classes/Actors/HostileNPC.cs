using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoL
{
   
    /// <summary>
    /// Class describing the actions of enemy NPCs.
    /// </summary>
    abstract class HostileNPC : NonPlayerCharacter
    {
        private Direction faceDirection;
        public bool isOnGround;

        public HostileNPC(Vector2 startPosition, int level, int totalHealth, int attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed) 
        {
            faceDirection = Direction.LEFT;
            movementSpeed = Settings.ENEMY_INITIAL_SPEED;
        }

        public override void Update(GameTime gameTime)
        {
            if (isOnGround)
            {
                if (faceDirection == Direction.RIGHT)
                {
                    base.Move(Direction.RIGHT);
                }
                else
                {
                    base.Move(Direction.LEFT);
                }
            }
        }

        private void TurnAround()
        {
            if (faceDirection > 0)
            {
                faceDirection = Direction.LEFT;
            }
            else
            {
                faceDirection = Direction.RIGHT;
            }

            base.AddForce(new Vector2(-PotentialSpeed.X, 0)); // Stopper spriten.
        }

        public override void HandleCollision(Collision collision)
        {
            Vector2 transVector = collision.getTranslationVector();
            Actor collidingActor = collision.getCollidingActor();

            if (transVector.Y < 0)
            {
                isOnGround = true;
            }

            if (transVector == Vector2.Zero)
            {
                if(isOnGround)
                    TurnAround();
            }

            base.HandleCollision(collision);
        }
    }
}
