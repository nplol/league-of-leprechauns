using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    abstract class AbstractAwareHostileNPC : HostileNPC
    {
        private List<PlayerCharacter> _observeablePlayerCharacters;
        
        public AbstractAwareHostileNPC(Vector2 startPosition, int level, int totalHealth, int attackSpeed, 
            int jumpSpeed) 
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed)
        {
            _observeablePlayerCharacters = findObserveablePlayerCharacters();
        }

        public override void Update(GameTime gameTime)
         {
             base.Update(gameTime);
             _observeablePlayerCharacters = findObserveablePlayerCharacters();
         }

        internal List<PlayerCharacter> GetObserveablePlayerCharacters(){
            return _observeablePlayerCharacters;
        }

        internal PlayerCharacter NearestPlayerCharacter()
         {
             if (_observeablePlayerCharacters.Count == 0)
                 return null;

             PlayerCharacter nearestPlayarCharacterFound = _observeablePlayerCharacters.ElementAt(0);
             int minDistance = findDistanceTo(nearestPlayarCharacterFound);
             foreach (PlayerCharacter playerCharacter in _observeablePlayerCharacters)
             {
                 if (playerCharacter == nearestPlayarCharacterFound)
                     continue;

                 int aDistance = findDistanceTo(playerCharacter);
                 if (minDistance > aDistance)
                 {
                     minDistance = aDistance;
                     nearestPlayarCharacterFound = playerCharacter;
                 }
             }
             return nearestPlayarCharacterFound;
         }

        internal void Mimic(PlayerCharacter player)
        {
            FollowPlayer(player);
            JumpIfPlayerJumps(player);
        }

        internal void FollowPlayer(PlayerCharacter player)
        {
            Direction playerDirection = PlayerDirection(player);
            Move(playerDirection);
            
        }

        internal void JumpIfPlayerJumps(PlayerCharacter player){
            if (player.animation.AnimationState == AnimationConstants.JUMPING)
                Jump();
        }

        private int findDistanceTo(Actor actor)
         {
             float xLength = CurrentPosition.X - actor.CurrentPosition.X;
             float yLength = CurrentPosition.Y - actor.CurrentPosition.Y;
             int distance = (int)(Math.Sqrt(xLength * xLength + yLength * yLength));
             return distance;
         }

        private Direction PlayerDirection(PlayerCharacter player)
        {
            float dx = CurrentPosition.X - player.CurrentPosition.X;
            if (dx < 0)
                return Direction.RIGHT;
            else if (dx > 0)
                return Direction.LEFT;
            else
                return Direction.UP;
        }

        private List<PlayerCharacter> findObserveablePlayerCharacters()
         {
             List<PlayerCharacter> list = new List<PlayerCharacter>();
             foreach (Actor actor in ActorManager.getListOfActiveActors())
                 if (actor is PlayerCharacter)
                     list.Add((PlayerCharacter)actor);
             return list;
         }
    }
}
