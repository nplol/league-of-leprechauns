﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL
{
    class Settings
    {
        //Settings class. All variables are static and global

        internal static int WINDOW_WIDTH = 1280;
        internal static int WINDOW_HEIGHT = 720;

        
        
        internal static int NUM_PLAYERS = 2;
        

        internal static int FORCE_THRESHOLD = 30;

        internal static float GRAVITY = 1;
        internal static float MAX_FALL_SPEED = 10;

        

        #region Player_Constants
        internal static int DEFAULT_JUMPFORCE = 19;
        internal static int PLAYER_INITIAL_SPEED = 10;
        internal static int PLAYER_LIVES = 3;
        internal static int CABBAGELIPS_HEALTH = 100;
        internal static int FLUFFERNUTTER_HEALTH = 100;
        #endregion


        #region Enemy_Constants
        internal static int ENEMY_INITIAL_SPEED = 5;
        internal static int ENEMY_JUMPFORCE = 5;

        internal static int ENEMY_MELEEGNOME_HEALTH = 30;
        internal static int ENEMY_FIREBALLGNOME_HEALTH = 30;
        #endregion

        #region Ability_Constants
        internal static int HIT_COOLDOWN = 333;
        internal static int HIT_DAMAGE = 6;
        internal static int THROW_COOLDOWN = 1000;
        internal static int THROW_DAMAGE = 10;
        internal static int THROW_LIFETIME = 2000;
        internal static int FIREBALL_LIFETIME = 2000;
        internal static int FIREBALL_COOLDOWN = 1000;
        internal static int FIREBALL_DAMAGE = 10;
        internal static int AOE_COOLDOWN = 3000;
        internal static int AOE_DAMAGE = 15;
        #endregion
    }
}
