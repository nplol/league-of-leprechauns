using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class FlufferNutter : PlayerCharacter
    {
        public FlufferNutter(Vector2 startPosition, int level, int totalHealth, Vector2 attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed)
        {

        }
    }
}
