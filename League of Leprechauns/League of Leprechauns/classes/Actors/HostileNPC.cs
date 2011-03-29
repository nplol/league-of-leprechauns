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
    class HostileNPC : Character
    {

        private List<PlayerCharacter> playerCharacters;

        public HostileNPC(Vector2 startPosition, int level, int totalHealth, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed) 
        {
            faceDirection = Direction.LEFT;
            movementSpeed = Settings.ENEMY_INITIAL_SPEED;

            this.playerCharacters = findPlayerCharacters();
        
            
            animation.AddAnimation(AnimationConstants.WALKING, 41, 92, 148, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 215, 90, 149, 1);
            animation.AddAnimation(AnimationConstants.STILL, 41, 92, 148, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Actor nearestPlayer = getNearestPlayer();


            

            if ( (nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 0) this.faceDirection = Direction.RIGHT;
            else if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) <= 0) this.faceDirection = Direction.LEFT;

            Console.WriteLine(faceDirection);
            

            if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 200)
            {
                base.Move(this.faceDirection);
                animation.SetCurrentAnimation(AnimationConstants.WALKING);
            }
            else if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) < -200)
            {
                base.Move(this.faceDirection);
                animation.SetCurrentAnimation(AnimationConstants.WALKING);
            }
            else
            {
                animation.SetCurrentAnimation(AnimationConstants.STILL);

            }
           
            
            
            animation.Update(gameTime);
        }

        private void TurnAround()
        {
            if (faceDirection == Direction.RIGHT)
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
            
            if (transVector.X < 0) faceDirection = Direction.LEFT;
            else if (transVector.X > 0) faceDirection = Direction.RIGHT;
            

            
           
            base.HandleCollision(collision);
        }

        public override void PerformAbility(LoL.AbilityNumber abilityNumber){
        }

        private List<PlayerCharacter> findPlayerCharacters()
        {
            List<PlayerCharacter> list = new List<PlayerCharacter>();
 // TODO : bytt til getListOfActiveActors
            foreach (Actor actor in ActorManager.getListOfAllActors())
            {
                Console.WriteLine(actor);
                if (actor is PlayerCharacter)
                    list.Add((PlayerCharacter)actor);
            }
            return list;
        }

        private Actor getNearestPlayer()
        {
            Actor nearestPlayer = playerCharacters.ElementAt(1);
            foreach (Actor player in playerCharacters)
            {
                if (Math.Abs((player.CurrentPosition.X - this.CurrentPosition.X)) < Math.Abs((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X))) nearestPlayer = player;

            }
            return nearestPlayer;
        }
    }
}
