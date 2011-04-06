using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;


namespace LoL
{
   
    /// <summary>
    /// Class describing the behaviour of hostile NPCs.
    /// </summary>
    abstract class HostileNPC : Character
    {
        #region Attributes
        private List<PlayerCharacter> playerCharacters;
        internal Actor nearestPlayer;
        #endregion

        #region Properties
        public Actor NearestPlayer
        {
            get { return nearestPlayer; }
        }
        #endregion


        protected HostileNPC(Vector2 startPosition)
            : base(startPosition) 
        {
            movementSpeed = Settings.ENEMY_INITIAL_SPEED;
            faceDirection = Direction.LEFT;
            
            this.playerCharacters = findPlayerCharacters();
            this.nearestPlayer = playerCharacters.ElementAt(0);
        }

        public override void Update(GameTime gameTime)
        {
            nearestPlayer = calculateNearestPlayer();

            if ( (nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > 0) this.faceDirection = Direction.RIGHT;
            else if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) <= 0) this.faceDirection = Direction.LEFT;
  
            animation.Update(gameTime);
           
            base.Update(gameTime);
        }

        /// <summary>
        /// Specifying specific behaviour for hostile NPCs when colliding with other actors.
        /// </summary>
        /// <param name="collision"></param>
        public override void HandleCollision(Collision collision)
        {
            Actor collidingActor = collision.CollidingActor;
            Vector2 transVector = collision.TranslationVector;

            /// If the hostile NPC collides with a playable character, then
            /// reset the translation vector so they can occupy the same space.
            if (collidingActor is PlayerCharacter)
                collision.TranslationVector = Vector2.Zero;

            /// Enables the hostile NPC to chase after playable characters by
            /// jumping over platforms.
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

            list.Add(ActorManager.GetFlufferNutterInstance);
            list.Add(ActorManager.GetCabbageLipsInstance);

            return list;
        }

        // Method to get the nearest playerCharacter that is at the same altitude as this character
        private Actor calculateNearestPlayer()
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
