﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of playable characters.
    /// </summary>
    abstract class PlayerCharacter : Character, IKeepActive
    {
        protected PlayerCharacter(Vector2 startPosition)
            : base(startPosition) 
        {

        }

        public virtual SoundEffect SpecialMove
        {
            get { return null; }
        }

        public virtual void Initialize(Vector2 startPosition)
        {
            CalculateCharacterLevel();
        }

        public override void HandleCollision(Collision collision)
        {
            Actor collidingActor = collision.CollidingActor;

            // If the player collides with an enemy, set the translation vector
            // to zero so that players and enemies can occupy the same space.
            if (collidingActor is HostileNPC)
                collision.TranslationVector = Vector2.Zero;

            // Only playable characters can activate buttons.
            if (collidingActor is Button)
                ((Button)collidingActor).ActivateButton();

            // If the player collides with the exit door, load the next level after a set amount of time (for panash).
            if (collidingActor is LevelExitDoor)
            {
                if (!LevelManager.GetInstance.getCurrentLevel().Finished)
                {
                    LevelManager.GetInstance.getCurrentLevel().Finished = true;
                    Timer timer = new Timer(500);
                    timer.TimeEndedEvent += new TimerDelegate(LeagueOfLeprechauns.GetInstance.ChangeLevel);
                    timer.Start();
                }
            }

            base.HandleCollision(collision);
        }

        /// <summary>
        /// This overridden version of ApplyForcesToActor makes sure
        /// none of the playable characters are able to move the camera so that
        /// the other is invisible.
        /// </summary>
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

        public void respawnCharacter()
        {
            this.healthPoints = this.totalHealthPoints;
            this.isDead = false;
            this.isSuspended = false;
        }

        public void resetCharacter()
        {
            respawnCharacter();
            ExperiencePoints = 0;
            CalculateCharacterLevel();
        }


    }
}
