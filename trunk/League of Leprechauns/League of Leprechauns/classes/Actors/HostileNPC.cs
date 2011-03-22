using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoL
{
    enum FaceDirection
    {
        Left = -1,
        Right = 1
    }
    /// <summary>
    /// Class describing the actions of enemy NPCs.
    /// </summary>
    class HostileNPC : NonPlayerCharacter
    {
        private FaceDirection faceDirection;
        public bool isOnGround;

        public FaceDirection FaceDirection
        {
            get { return faceDirection; }
        }

        public HostileNPC(Vector2 startPosition, int level, int totalHealth, Vector2 attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed) 
        {
            faceDirection = FaceDirection.Left;
            movementSpeed = Settings.ENEMY_INITIAL_SPEED;
        }

        public override void Update(GameTime gameTime)
        {
            if (isOnGround)
            {
                if (faceDirection > 0)
                {
                    base.Move(Direction.RIGHT);
                }
                else
                {
                    base.Move(Direction.LEFT);
                }
            }
        }

        public void TurnAround()
        {
            if (faceDirection > 0)
            {
                faceDirection = FaceDirection.Left;
            }
            else
            {
                faceDirection = FaceDirection.Right;
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
