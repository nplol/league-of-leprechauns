using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace LoL
{
    abstract class PlayerCharacter : Character
    {

        #region Properties

        public int AbilityPoints
        {
            get;
            set;
        }

        public int ExperiencePoints
        {
            get;
            set;
        }

        #endregion

        public PlayerCharacter(Vector2 startPosition, int level, int totalHealthPoints, int jumpSpeed)
            : base(startPosition, level, totalHealthPoints, jumpSpeed) 
        {
            AbilityPoints = 0;
            ExperiencePoints = 0;
            movementSpeed = Settings.PLAYER_INITIAL_SPEED;
        }

        public override void Update(GameTime gameTime)
        {
            if (this.healthPoints <= 0)
            {
                //TODO: What is supposed to happen if healthPoints reach zero?
                //Respawn();
            }
            base.Update(gameTime);
        }

        public override void HandleCollision(Collision collision)
        {
            base.HandleCollision(collision);
            if (collision.getCollidingActor() is HostileNPC && Math.Abs(collision.getTranslationVector().Y) > 0  ) this.TakeDamage(Settings.COLLIDE_WITH_ENEMY_DAMAGE);
            
        }


        public override void ApplyForcesToActor()
        {
            Vector2 cameraPosition = Camera.GetInstance().Position;
            Vector2 nextMovement = this.currentForce + this.currentSpeed;
            Vector2 collisionForce = new Vector2(0,0);

            if (nextMovement.X > 0)
            {
                collisionForce.X = (CurrentPosition.X + nextMovement.X + BoundingRectangle.Width) - (cameraPosition.X + Settings.WINDOW_WIDTH);
                if (collisionForce.X > 0)
                {
                    AddForce(-collisionForce);
                }
            }
            else if (nextMovement.X < 0)
            {
                collisionForce.X = (cameraPosition.X) - (CurrentPosition.X + nextMovement.X);
                if (collisionForce.X > 0)
                {
                    AddForce(collisionForce);
                }
            }
            base.ApplyForcesToActor();
        }

        private void Respawn()
        {
            this.healthPoints = this.TotalHealthPoints;
            //TODO: logikk for å flytte player opp på brett igjen hvis den detter ned!

        }

                
    }
}
