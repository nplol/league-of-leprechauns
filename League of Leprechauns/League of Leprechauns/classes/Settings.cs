
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
        internal static int CABBAGELIPS_INITIAL_SPEED = 10;
        internal static int FLUFFERNUTTER_INITIAL_SPEED = 8;
        internal static int CABBAGELIPS_HEALTH = 200;
        internal static int FLUFFERNUTTER_HEALTH = 100;
        internal static int COLLIDE_WITH_ENEMY_DAMAGE = 1;
        internal static int[] LEVEL_XP_CONSTANTS = { 0, 500, 1000, 2000, 4000, 8000 };
        #endregion


        #region Enemy_Constants
        internal static int ENEMY_INITIAL_SPEED = 5;
        internal static int ENEMY_JUMPFORCE = 15;

        internal static int ENEMY_MELEEGNOME_HEALTH = 30;
        internal static int ENEMY_FIREBALLGNOME_HEALTH = 30;

        internal static int NACKLEBIDDLE_HEALTH = 200;
        internal static int NACKLEBIDDLE_JUMPFORCE = 15;
        #endregion

        #region Ability_Constants
        internal static float SHOOT_SPEED = 10f;
        internal static int HIT_COOLDOWN = 500;
        internal static int HIT_DAMAGE = 6;
        internal static int THROW_COOLDOWN = 800;
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
