using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace LoL
{
    class NonPlayerCharacter : Character
    {
        public NonPlayerCharacter(Vector2 startPosition, int level, Vector2 startSpeed, int totalHealth, Vector2 attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed)
        {
            
        }

        public override void HandleCollision(Collision collision)
        {
            
        }

    }
}
