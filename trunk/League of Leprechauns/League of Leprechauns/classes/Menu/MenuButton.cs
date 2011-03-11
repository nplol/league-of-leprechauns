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

        ContentManager contentManager;
        bool selected;
      
       
        public MenuButton(string assetName, Vector2 position, ContentManager contentManager)
        {
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 500, 80);
            this.assetName = assetName;
            this.contentManager = contentManager;
            this.buttonTexture = contentManager.Load<Texture2D>(assetName);
            this.menuButton = buttonTexture;
            this.pressedTexture = contentManager.Load<Texture2D>(assetName+"Pressed");
            this.selected = false;
        }

        public string getAssetName() { return assetName; }

      
        public void Draw(SpriteBatch spriteBatch)
        {

            if (selected)
            {
                spriteBatch.Draw(menuButton, rectangle, Color.White);
            }
            else spriteBatch.Draw(menuButton, rectangle, Color.LightGray);
        }

        public void setSelected(Boolean selected) { this.selected = selected; }
        public Boolean isSelected(){ return this.selected; }

        public void setButtonToPressed()
        {
           this.menuButton = pressedTexture;
        }

        public void setButtonToNotPressed()
        {
           this.menuButton = this.buttonTexture;
        }
        

    }


}
