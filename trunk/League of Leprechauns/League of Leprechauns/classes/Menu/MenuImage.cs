using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    class MenuImage
    {
        private string assetName;
        private Vector2 position;
        private Texture2D texture;

        /// <summary>
        /// Creates a menuImage and loads the sprite according to the asset name, at the given position
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="position"></param>
        /// <param name="contentManager"></param>
        internal MenuImage(string assetName, Vector2 position)
        {
            this.assetName = assetName;
            this.position = position;
            this.texture = GlobalVariables.ContentManager.Load<Texture2D>(assetName);
        }

        /// <summary>
        /// Draws the image
        /// </summary>
        /// <param name="spriteBatch"></param>
        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
         
        }
    }
}
