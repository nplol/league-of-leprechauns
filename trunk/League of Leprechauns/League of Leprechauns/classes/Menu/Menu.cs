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
        private List<MenuButton> menuButtons;
        private string backgroundAssetName;
        private int selectedMenuButton = 0;
        private Texture2D menuBackground;
        private Rectangle rectangle;
        private List<MenuText> menuTextList;
        private List<MenuImage> menuImageList;


        public Menu(string backgroundAssetName, Rectangle rectangle)
        {
            this.backgroundAssetName = backgroundAssetName;
            this.rectangle = rectangle;
            this.menuButtons = new List<MenuButton>();
            this.menuTextList = new List<MenuText>();
            this.menuImageList = new List<MenuImage>();
        }

        public void AddMenuButton(MenuButton button)
        {
            if (menuButtons.Count == 0) button.setSelected(true);
            menuButtons.Add(button);            

        }

        public void AddMenuText(MenuText menuText)
        {
            menuTextList.Add(menuText);
        }

        public void AddMenuImage(MenuImage menuImage)
        {
            menuImageList.Add(menuImage);
        }

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            menuBackground = theContentManager.Load<Texture2D>(theAssetName);   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuBackground, rectangle, Color.White);
            foreach (MenuButton button in menuButtons) button.Draw(spriteBatch);
            foreach (MenuText menuText in menuTextList) menuText.Draw(spriteBatch);
            foreach (MenuImage menuImage in menuImageList) menuImage.Draw(spriteBatch);

        }

        /// <summary>
        /// Changes the selected button in the menu to the one below the currently selected.
        /// </summary>
        internal void changeSelectionDown()
        {
            menuButtons.ElementAt(selectedMenuButton).setSelected(false);
            selectedMenuButton++;
            menuButtons.ElementAt(selectedMenuButton).setSelected(true);
        }
        /// <summary>
        /// Changes the selected button in the menu to the one above the currently selected.
        /// </summary>
        internal void changeSelectionUp()
        {
            menuButtons.ElementAt(selectedMenuButton).setSelected(false);
            selectedMenuButton--;
            menuButtons.ElementAt(selectedMenuButton).setSelected(true);
        }

        /// <summary>
        /// Help method to avoid the selection to go out of bounds
        /// </summary>
        /// <returns></returns>
        internal bool notAtTop()
        {
            return selectedMenuButton > 0;        
        }

        /// <summary>
        /// Help method to avoid the selection to go out of bounds
        /// </summary>
        /// <returns></returns>
        internal Boolean notAtBottom()
        {
            return selectedMenuButton < menuButtons.Count - 1;
        }

        internal MenuButton getSelectedButton()
        {
            return menuButtons.ElementAt(selectedMenuButton);
        }
    }
}
