
namespace LoL
{
    /// <summary>
    /// Class containing game settings
    /// </summary>
    class Settings
    {
        internal static int WINDOW_WIDTH = 1280;
        internal static int WINDOW_HEIGHT = 720;

        internal static int NUM_PLAYERS = 2;

        internal static int FORCE_THRESHOLD = 30;
        internal static float GRAVITY = 1;
        internal static float MAX_FALL_SPEED = 10;
        internal static int MAXIMUM_LEVEL_DEPTH = 200;

        #region Player_Constants
        internal static int CABBAGELIPS_JUMPFORCE = 19;
        internal static int CABBAGELIPS_INITIAL_SPEED = 10;
        internal static int CABBAGELIPS_HEALTH = 200;
        internal static int CABBAGELIPS_HIT_DAMAGE = 6;
        internal static int CABBAGELIPS_HIT_COOLDOWN = 500;
        internal static int CABBAGELIPS_AOE_DAMAGE = 15;
        internal static int CABBAGELIPS_AOE_COOLDOWN = 3000;
        internal static int FLUFFERNUTTER_JUMPFORCE = 19;
        internal static int FLUFFERNUTTER_INITIAL_SPEED = 8;
        internal static int FLUFFERNUTTER_HEALTH = 100;
        internal static int FLUFFERNUTTER_THROW_DAMAGE = 10;
        internal static int FLUFFERNUTTER_THROW_COOLDOWN = 800;
        internal static int COLLIDE_WITH_ENEMY_DAMAGE = 1;
        internal static int[] LEVEL_XP_CONSTANTS = { 0, 1000, 2000, 4000, 8000, 16000};
        #endregion

        #region Enemy_Constants

        #region Nacklebiddle
        internal static int NACKLEBIDDLE_HEALTH = 200;
        internal static int NACKLEBIDDLE_JUMPFORCE = 25;
        internal static int NACKLEBIDDLE_HIT_DAMAGE = 10;
        internal static int NACKLEBIDDLE_HIT_COOLDOWN = 1500;
        internal static int NACKLEBIDDLE_AOE_DAMAGE = 50;
        internal static int NACKLEBIDDLE_AOE_COOLDOWN = 1000;
        internal static int NACKLEBIDDLE_ICEFLAME_COOLDOWN = 1500;
        internal static int NACKLEBIDDLE_ICEFLAME_DAMAGE = 10;
        #endregion


        #region Gnome
        internal static int GNOME_MELEE_HEALTH = 30;
        internal static int GNOME_RANGED_HEALTH = 30;
        internal static int GNOME_INITIAL_SPEED = 5;
        internal static int GNOME_JUMPFORCE = 15;
        internal static int GNOME_FIREBALL_COOLDOWN = 1000;
        internal static int GNOME_FIREBALL_DAMAGE = 10;
        internal static int GNOME_HIT_DAMAGE = 6;
        internal static int GNOME_HIT_COOLDOWN = 500;
        #endregion

        #endregion

        #region Ability_Constants
        internal static int DEFAULT_ABILITY_LIFETIME = 100;
        internal static float SHOOT_SPEED = 10f;
        internal static int SHOOT_LIFETIME = 2000;
        internal static float HIT_SPEED = 8f;
        #endregion


    }
}
