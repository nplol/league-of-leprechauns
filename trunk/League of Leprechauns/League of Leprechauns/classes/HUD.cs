﻿using Microsoft.Xna.Framework;
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

        /// <summary>
        /// Constructs the HUD.
        /// </summary>
        public HUD()
        {
            flufferAvatar = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Characters/fluffernutterAvatar");
            cabbageAvatar = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Characters/cabbagelipsAvatar");
            flufferAvatarPosition = new Vector2(30, 10);
            cabbageAvatarPosition = new Vector2(Settings.WINDOW_WIDTH - cabbageAvatar.Width - 30, 10);

            flufferHPBar = new Bar(100, 15, new Vector2(flufferAvatarPosition.X, flufferAvatarPosition.Y + flufferAvatar.Height + 10));
            cabbageHPBar = new Bar(100, 15, new Vector2(cabbageAvatarPosition.X, cabbageAvatarPosition.Y + cabbageAvatar.Height + 10));

        }

        /// <summary>
        /// Draws the avatars and HP-bars on screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            flufferHPBar.Draw(spriteBatch, CalculatePercent(ActorManager.GetFlufferNutterInstance.TotalHealthPoints, ActorManager.GetFlufferNutterInstance.HealthPoints));
            cabbageHPBar.Draw(spriteBatch, CalculatePercent(ActorManager.GetCabbageLipsInstance.TotalHealthPoints, ActorManager.GetCabbageLipsInstance.HealthPoints));

            spriteBatch.Draw(flufferAvatar, flufferAvatarPosition, Color.White);
            spriteBatch.Draw(cabbageAvatar, cabbageAvatarPosition, Color.White);
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
