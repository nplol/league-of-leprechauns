using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LoL
{
    class Menu
    {
        private string menuName;
        private List<MenuButton> menuButtons;
        private string assetName;
        private int selectedMenuButton = 0;
        private Texture2D menuBackground;
        private Rectangle rectangle;
        private KeyboardState newState;
        private KeyboardState oldState;

        public int CurrentSelectedMenuButton { get { return selectedMenuButton; } set { selectedMenuButton = value; } }

        public Menu(string assetName, string menuName, Rectangle rectangle)
        {
            this.assetName = assetName;
            this.menuName = menuName;
            this.rectangle = rectangle;
            this.menuButtons = new List<MenuButton>();      
        }

        public void AddMenuButton(MenuButton button)
        {
            if (menuButtons.Count == 0) button.setSelected(true);
            menuButtons.Add(button);
            

        }

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            menuBackground = theContentManager.Load<Texture2D>(theAssetName);
            //frame = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuBackground, rectangle, Color.White);
            foreach (MenuButton button in menuButtons) button.Draw(spriteBatch);

        }

        internal void changeSelectionDown()
        {
            menuButtons.ElementAt(selectedMenuButton).setSelected(false);
            selectedMenuButton++;
            menuButtons.ElementAt(selectedMenuButton).setSelected(true);
        }

        internal void changeSelectionUp()
        {
            menuButtons.ElementAt(selectedMenuButton).setSelected(false);
            selectedMenuButton--;
            menuButtons.ElementAt(selectedMenuButton).setSelected(true);
        }

        internal bool notAtTop()
        {
            
            
            return selectedMenuButton > 0;
            
        }


        internal MenuButton getSelectedButton()
        {
            return menuButtons.ElementAt(selectedMenuButton);
        }

        internal Boolean notAtBottom()
        {
            return selectedMenuButton < menuButtons.Count - 1;
        }
    }
}
