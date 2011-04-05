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
        ContentManager contentManager;
        bool selected;
      
       
        public MenuButton(string assetName, Vector2 position, ContentManager contentManager, Texture2D arrow)
        {
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 500, 80);
            this.assetName = assetName;
            this.contentManager = contentManager;

            this.selected = false;
            this.buttonFont = contentManager.Load<SpriteFont>("Sprites/SpriteFonts/ButtonFont");
            this.position = position;
            this.arrow = arrow;

        }

        public string getAssetName() { return assetName; }

      
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
        public void setSelected(Boolean selected) { this.selected = selected; }
     
        public Boolean isSelected(){ return this.selected; }

        /// <summary>
        /// Changes the texture when the button is pressed
        /// </summary>
        public void setButtonToPressed()
        {
           //TODO: Sette texten til en annen farge, litt mørkere
        }

        /// <summary>
        /// Changes the texture back
        /// </summary>
        public void setButtonToNotPressed()
        {
            //TODO: Sette texten til original farge, litt mørkere
        }
        

    }


}
