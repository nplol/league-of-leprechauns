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
        private Actor nearestPlayer;

        public HostileNPC(Vector2 startPosition, int characterLevel, int totalHealth, int jumpSpeed)
            : base(startPosition, characterLevel, totalHealth, jumpSpeed) 
        {
            faceDirection = Direction.LEFT;
            movementSpeed = Settings.ENEMY_INITIAL_SPEED;

            this.playerCharacters = findPlayerCharacters();
            this.nearestPlayer = playerCharacters.ElementAt(0);
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

            list.Add(ActorManager.GetFlufferNutterInstance());
            list.Add(ActorManager.GetCabbageLipsInstance());

            return list;
        }

        // Method to get the nearest playerCharacter that is on the same level of this character
        public Actor getNearestPlayer()
        {
            List<Actor> eligibleCharacters = new List<Actor>();
            
            foreach (Actor character in playerCharacters)
            {
                if (IsAtSameLevel(this, character)) eligibleCharacters.Add(character);
                                
            }

            if (eligibleCharacters.Count == 0) return nearestPlayer;
            else
            {
                nearestPlayer = eligibleCharacters.ElementAt(0);
                foreach (Actor eligibleCharacter in eligibleCharacters)
                {
                    if ((Math.Abs((eligibleCharacter.CurrentPosition.X - this.CurrentPosition.X)) < Math.Abs((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X))))
                    {
                        nearestPlayer = eligibleCharacter;


                    }
                }
                return nearestPlayer;
            }
        }

        // Help method to check whether two characters are on the same level
        private Boolean IsAtSameLevel(Actor actor1, Actor actor2)
        {
            
            return (actor1.CurrentPosition.Y - actor1.BoundingRectangle.Height +14 < actor2.CurrentPosition.Y) && (actor1.CurrentPosition.Y + actor1.BoundingRectangle.Y + 10 > actor2.CurrentPosition.Y);
        }
    }
}
