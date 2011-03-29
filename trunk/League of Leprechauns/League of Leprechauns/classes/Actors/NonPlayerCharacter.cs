using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace LoL
{
    abstract class NonPlayerCharacter : Character
    {
        public NonPlayerCharacter(Vector2 startPosition, int level, int totalHealth, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed)
        {
            
        }

    }
}
