using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace LoL
{
    class PlayerCharacter : Character
    {
        private int abilityPoints;
        private int experiencePoints;

        public PlayerCharacter(Vector2 startPosition) : base(startPosition) { }
    }
}
