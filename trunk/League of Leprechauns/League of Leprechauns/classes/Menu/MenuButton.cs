using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LoL
{
    class MenuButton
    {
        string assetName;
        Rectangle rectangle;
        Texture2D buttonTexture;
        Texture2D pressedTexture;
        Texture2D menuButton;
        SpriteFont buttonFont;
        Vector2 position;
        ContentManager contentManager;
        bool selected;
      
       
        public MenuButton(string assetName, Vector2 position, ContentManager contentManager)
        {
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 500, 80);
            this.assetName = assetName;
            this.contentManager = contentManager;
            this.buttonTexture = contentManager.Load<Texture2D>("Sprites/MenuButtons/button");
            this.menuButton = buttonTexture;
            this.pressedTexture = contentManager.Load<Texture2D>("Sprites/MenuButtons/buttonPressed");
            this.selected = false;
            this.buttonFont = contentManager.Load<SpriteFont>("ButtonFont");
            this.position = position;

        }

        public string getAssetName() { return assetName; }

      
        public void Draw(SpriteBatch spriteBatch)
        {

            if (selected)
            {
                spriteBatch.Draw(menuButton, rectangle, Color.White);
                spriteBatch.DrawString(buttonFont, assetName, new Vector2(position.X + 250 - (assetName.Length*13), position.Y + 15), Color.Black);
            }
            else
            {
                spriteBatch.Draw(menuButton, rectangle, Color.LightGray);
                spriteBatch.DrawString(buttonFont, assetName, new Vector2(position.X + 250 - (assetName.Length * 13), position.Y + 15), Color.Black);
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
           this.menuButton = pressedTexture;
        }

        /// <summary>
        /// Changes the texture back
        /// </summary>
        public void setButtonToNotPressed()
        {
           this.menuButton = this.buttonTexture;
        }
        

    }


}
