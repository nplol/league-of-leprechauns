using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LoL
{
    class MenuButton
    {
        string assetName;
        Rectangle rectangle;
        SpriteFont buttonFont;
        Vector2 position;
        Texture2D arrow;
        bool selected;
      
        /// <summary>
        /// Creates a menuButton
        /// loads the buttonFont
        /// sets the button at the given position in the menu
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="position"></param>
        /// <param name="contentManager"></param>
        /// <param name="arrow"></param>
        public MenuButton(string assetName, Vector2 position, Texture2D arrow)
        {
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 500, 80);
            this.assetName = assetName;

            this.selected = false;
            this.buttonFont = GlobalVariables.ContentManager.Load<SpriteFont>("Sprites/SpriteFonts/ButtonFont");
            this.position = position;
            this.arrow = arrow;
        }

        public string GetAssetName() { return assetName; }

        /// <summary>
        /// Draws the button
        /// checks if it is selected or not and draws accordingly
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {

            if (selected)
            {
                spriteBatch.DrawString(buttonFont, assetName, new Vector2(position.X, position.Y), new Color(225, 132, 0));
                spriteBatch.Draw(arrow, new Rectangle((int)(position.X - 150),(int)(position.Y - 40),arrow.Width,arrow.Height), Color.White);
                
            }
            else
            {
                spriteBatch.DrawString(buttonFont, assetName, new Vector2(position.X, position.Y), Color.Black);
            }
        }
        /// <summary>
        /// Sets whether this button is selected, so the draw method can draw the correct texture
        /// </summary>
        /// <param name="selected"></param>
        public void SetSelected(Boolean selected) { this.selected = selected; }
     
        public Boolean IsSelected(){ return this.selected; }
    }


}
