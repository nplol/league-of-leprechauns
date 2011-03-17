using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private ContentManager contentManager;

        public MenuImage(string assetName, Vector2 position, ContentManager contentManager)
        {
            this.assetName = assetName;
            this.position = position;
            this.contentManager = contentManager;
            this.texture = contentManager.Load<Texture2D>(assetName);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
         
        }
    }
}
