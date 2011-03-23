using System;
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

        internal static int PLAYER_INITIAL_SPEED = 10;
        internal static int ENEMY_INITIAL_SPEED = 5;
        internal static int NUM_PLAYERS = 2;

        internal static int FORCE_THRESHOLD = 30;

        internal static float GRAVITY = 1;
        internal static float MAX_FALL_SPEED = 10;

        internal static int DEFAULT_JUMPFORCE = 19;
    }
}
