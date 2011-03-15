using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class FriendlyNPC : NonPlayerCharacter
    {
        public FriendlyNPC(Vector2 startPosition, int level, Vector2 startSpeed, int totalHealth, Vector2 attackSpeed, int jumpSpeed)
            : base(startPosition, level, startSpeed, totalHealth, attackSpeed, jumpSpeed)
        { 
        }
    }
}
