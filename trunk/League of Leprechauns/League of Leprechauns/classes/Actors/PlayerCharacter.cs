using Microsoft.Xna.Framework;


namespace LoL
{
    abstract class PlayerCharacter : Character, IKeepActive
    {

        #region Properties

        public int AbilityPoints { get; private set; }

        #endregion

        protected PlayerCharacter(Vector2 startPosition, int characterLevel, int totalHealthPoints, int jumpSpeed)
            : base(startPosition, characterLevel, totalHealthPoints, jumpSpeed) 
        {
            AbilityPoints = 0;
        }

        public void Initialize(Vector2 startPosition, int characterLevel, int totalHealthPoints, int jumpSpeed)
        {
            this.CurrentPosition = startPosition;
            this.CharacterLevel = characterLevel;
            this.totalHealthPoints = totalHealthPoints;
            this.healthPoints = totalHealthPoints;
            this.jumpSpeed = jumpSpeed;
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
            Actor collidingActor = collision.getCollidingActor();

            if (collidingActor is HostileNPC)
                collision.setTranslationVector(Vector2.Zero);

            if (collidingActor is Button)
                ((Button)collidingActor).ActivateButton();

            if (collidingActor is LevelExitDoor)
            {
                LevelManager.GetInstance.ChangeLevel();
            }

            base.HandleCollision(collision);
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

        public void resetCharacter()
        {
            this.healthPoints = this.totalHealthPoints;
            this.isDead = false;
            this.isSuspended = false;
        }

                
    }
}
