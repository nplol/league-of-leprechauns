﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class PlayerCharacter : Character
    {
        private int abilityPoints;
        private int experiencePoints;

        public PlayerCharacter(Texture2D texture) : base(texture) { }
    }
}
