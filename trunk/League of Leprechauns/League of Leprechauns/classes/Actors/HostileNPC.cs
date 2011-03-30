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
    abstract class HostileNPC : Character
    {

        private List<PlayerCharacter> playerCharacters;

        public HostileNPC(Vector2 startPosition, int level, int totalHealth, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed) 
        {
            faceDirection = Direction.LEFT;
            movementSpeed = Settings.ENEMY_INITIAL_SPEED;

            this.playerCharacters = findPlayerCharacters();
        
            
           

        }

        public override void Update(GameTime gameTime)
        {
            

            Actor nearestPlayer = getNearestPlayer();

        
            if ( (nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 0) this.faceDirection = Direction.RIGHT;
            else if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) <= 0) this.faceDirection = Direction.LEFT;

                  
             
            animation.Update(gameTime);
           

            base.Update(gameTime);
        }


        public override void HandleCollision(Collision collision)
        {
            Actor collidingActor = collision.getCollidingActor();
            Vector2 transVector = collision.getTranslationVector();

            if (Math.Abs(transVector.X) > 2 && collidingActor is Platform)
            {
                base.Jump();
                Jumping = true;
            }

            base.HandleCollision(collision);
        }



        private List<PlayerCharacter> findPlayerCharacters()
        {
            List<PlayerCharacter> list = new List<PlayerCharacter>();

        // Change to getListOfActiveActors

            foreach (Actor actor in ActorManager.getListOfAllActors())
            {
                if (actor is PlayerCharacter)
                    list.Add((PlayerCharacter)actor);
            }
            return list;
        }

        public Actor getNearestPlayer()
        {
            Actor nearestPlayer = playerCharacters.ElementAt(0);
            foreach (Actor player in playerCharacters)
            {
                if (Math.Abs((player.CurrentPosition.X - this.CurrentPosition.X)) < Math.Abs((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X))) nearestPlayer = player;

            }
            return nearestPlayer;
        }
    }
}
