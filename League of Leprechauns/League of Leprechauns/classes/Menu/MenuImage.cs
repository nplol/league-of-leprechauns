﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    class MenuImage
    {
        private string assetName;
        private Vector2 position;
        private Texture2D texture;
        private ContentManager contentManager;

        /// <summary>
        /// Creates a menuImage and loads the sprite according to the asset name, at the given position
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="position"></param>
        /// <param name="contentManager"></param>
        public MenuImage(string assetName, Vector2 position, ContentManager contentManager)
        {
            this.assetName = assetName;
            this.position = position;
            this.contentManager = contentManager;
            this.texture = contentManager.Load<Texture2D>(assetName);
        }

        /// <summary>
        /// Draws the image
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
         
        }
    }
}
