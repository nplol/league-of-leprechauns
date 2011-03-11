using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace LoL
{
    class NonPlayerCharacter : Character
    {
        public NonPlayerCharacter(Vector2 startPosition, Vector2 startSpeed, int totalHealth, Vector2 attackSpeed, int jumping)
            : base(startPosition, startSpeed, totalHealth, attackSpeed, jumping)
        {
 
        }
    }
}
