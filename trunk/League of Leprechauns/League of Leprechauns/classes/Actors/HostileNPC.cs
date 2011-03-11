﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace LoL
{
    class HostileNPC : NonPlayerCharacter
    {
        public HostileNPC(Vector2 startPosition, int level, Vector2 startSpeed, int totalHealth, Vector2 attackSpeed, int jumping)
            : base(startPosition, level, startSpeed, totalHealth, attackSpeed, jumping) 
        {

        }
    }
}