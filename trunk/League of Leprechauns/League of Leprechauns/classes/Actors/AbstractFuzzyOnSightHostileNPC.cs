using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    abstract class AbstractFuzzyOnSightHostileNPC : AbstractOnSightHostileNPC
    {
        private int _unceraintyConstant;
        
        public AbstractFuzzyOnSightHostileNPC(Vector2 startPosition, int level, int totalHealth, int attackSpeed, 
            int jumpSpeed, int uncertaintyConstant, int sightDistance) 
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed, sightDistance)
        {
            _unceraintyConstant = uncertaintyConstant;
        }

        internal Vector2 GetPossibleAbilityPosition()
        {
            throw new NotImplementedException();
        }

        internal Vector2 GetPossiblePositionOfNearestCharacter()
        {
            PlayerCharacter playerCharacter = NearestPlayerCharacter();
            Vector2 fuzzyPosition = playerCharacter.CurrentPosition + uncertaintyVector(playerCharacter);
            return fuzzyPosition;
        }

        private Vector2 uncertaintyVector(PlayerCharacter playerCharacter)
        {
            Random aRandom = new Random();
            int min = Math.Min((int)faceDirection * _unceraintyConstant, 0);
            int max = Math.Max((int)faceDirection * _unceraintyConstant, 0);

            return new Vector2(aRandom.Next(min, max),
                aRandom.Next(-1*_unceraintyConstant, _unceraintyConstant));
        }

    }
}
