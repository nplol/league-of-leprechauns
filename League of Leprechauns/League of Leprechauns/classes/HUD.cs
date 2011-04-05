using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class HUD
    {
        private Bar flufferHPBar;
        private Bar cabbageHPBar;
        private Texture2D flufferAvatar;
        private Texture2D cabbageAvatar;

        private Vector2 flufferAvatarPosition;
        private Vector2 cabbageAvatarPosition;

        private Vector2 flufferLevelPosition, cabbageLevelPosition;
        private Vector2 flufferExpPosition, cabbageExpPosition;

        private SpriteFont levelFont;

        /// <summary>
        /// Constructs the HUD.
        /// </summary>
        public HUD()
        {
            flufferAvatar = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Characters/fluffernutterAvatar");
            cabbageAvatar = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Characters/cabbagelipsAvatar");
            flufferAvatarPosition = new Vector2(30, 10);
            cabbageAvatarPosition = new Vector2(Settings.WINDOW_WIDTH - cabbageAvatar.Width - 50, 10);

            flufferHPBar = new Bar(100, 15, new Vector2(flufferAvatarPosition.X, flufferAvatarPosition.Y + flufferAvatar.Height + 10));
            cabbageHPBar = new Bar(100, 15, new Vector2(cabbageAvatarPosition.X, cabbageAvatarPosition.Y + cabbageAvatar.Height + 10));

            levelFont = GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/MenuInfoFont");
            flufferLevelPosition = new Vector2(flufferAvatarPosition.X, flufferAvatarPosition.Y + flufferAvatar.Height + 25);
            cabbageLevelPosition = new Vector2(cabbageAvatarPosition.X, cabbageAvatarPosition.Y + cabbageAvatar.Height + 25);

            flufferExpPosition = new Vector2(flufferLevelPosition.X, flufferLevelPosition.Y + 25);
            cabbageExpPosition = new Vector2(cabbageLevelPosition.X, cabbageLevelPosition.Y + 25);
        }

        /// <summary>
        /// Draws the avatars and HP-bars on screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            FlufferNutter fluff = ActorManager.GetFlufferNutterInstance;
            CabbageLips cabb = ActorManager.GetCabbageLipsInstance;

            spriteBatch.Draw(flufferAvatar, flufferAvatarPosition, Color.White);
            spriteBatch.Draw(cabbageAvatar, cabbageAvatarPosition, Color.White);

            flufferHPBar.Draw(spriteBatch, CalculatePercent(fluff.TotalHealthPoints, fluff.HealthPoints));
            cabbageHPBar.Draw(spriteBatch, CalculatePercent(cabb.TotalHealthPoints, cabb.HealthPoints));

            spriteBatch.DrawString(levelFont, "Level " + fluff.CharacterLevel, flufferLevelPosition, Color.Orange);
            spriteBatch.DrawString(levelFont, "Level " + cabb.CharacterLevel, cabbageLevelPosition, Color.Orange);

            spriteBatch.DrawString(levelFont, "(" + (fluff.ExperiencePoints - Settings.LEVEL_XP_CONSTANTS[fluff.CharacterLevel - 1]) + "/" + Settings.LEVEL_XP_CONSTANTS[fluff.CharacterLevel] + ")", flufferExpPosition, Color.Orange);
            spriteBatch.DrawString(levelFont, "(" + (cabb.ExperiencePoints - Settings.LEVEL_XP_CONSTANTS[cabb.CharacterLevel - 1]) + "/" + Settings.LEVEL_XP_CONSTANTS[cabb.CharacterLevel] + ")", cabbageExpPosition, Color.Orange);
        }

        /// <summary>
        /// Calculates how much a value is of a max value in percentage.
        /// </summary>
        /// <param name="Max"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public static int CalculatePercent(int Max, int current)
        {
            return 100 - (int)(((Max - current) / (float)Max) * 100);
        }
    }
}
