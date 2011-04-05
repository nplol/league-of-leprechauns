using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

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

        /// <summary>
        /// Creates a Menu object.
        /// </summary>
        /// <param name="backgroundAssetName">BackgroundAsset for the menu</param>
        /// <param name="rectangle">Size of the background</param>
        internal Menu(string backgroundAssetName, Rectangle rectangle)
        {
            this.backgroundAssetName = backgroundAssetName;
            this.rectangle = rectangle;
            this.menuButtons = new List<MenuButton>();
            this.menuTextList = new List<MenuText>();
            this.menuImageList = new List<MenuImage>();
        }

        /// <summary>
        /// Adds a menuButton to this Menu and sets the first added menuButton as selected
        /// </summary>
        /// <param name="button"></param>
        internal void AddMenuButton(MenuButton button)
        {
            if (menuButtons.Count == 0) button.SetSelected(true);
            menuButtons.Add(button);            
        }

        /// <summary>
        /// Adds menuText to this Menu
        /// </summary>
        /// <param name="menuText"></param>
        internal void AddMenuText(MenuText menuText)
        {
            menuTextList.Add(menuText);
        }

        /// <summary>
        /// Adds menuImage to this Menu
        /// </summary>
        /// <param name="menuImage"></param>
        internal void AddMenuImage(MenuImage menuImage)
        {
            menuImageList.Add(menuImage);
        }

        /// <summary>
        /// Loads the menuBackground from the gives assetName
        /// </summary>
        /// <param name="theContentManager"></param>
        /// <param name="theAssetName"></param>
        internal void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            menuBackground = theContentManager.Load<Texture2D>(theAssetName);   
        }

        /// <summary>
        /// Draws this Menu and all of its components
        /// </summary>
        /// <param name="spriteBatch"></param>
        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuBackground, Vector2.Zero, Color.White);
            foreach (MenuButton button in menuButtons) button.Draw(spriteBatch);
            foreach (MenuText menuText in menuTextList) menuText.Draw(spriteBatch);
            foreach (MenuImage menuImage in menuImageList) menuImage.Draw(spriteBatch);
        }

        /// <summary>
        /// Changes the selected button in the menu to the one below the currently selected.
        /// </summary>
        internal void ChangeSelectionDown()
        {
            if (NotAtBottom())
            {
                menuButtons.ElementAt(selectedMenuButton).SetSelected(false);
                selectedMenuButton++;
                menuButtons.ElementAt(selectedMenuButton).SetSelected(true);
            }
        }
        /// <summary>
        /// Changes the selected button in the menu to the one above the currently selected.
        /// </summary>
        internal void ChangeSelectionUp()
        {
            if (NotAtTop())
            {
                menuButtons.ElementAt(selectedMenuButton).SetSelected(false);
                selectedMenuButton--;
                menuButtons.ElementAt(selectedMenuButton).SetSelected(true);
            }
        }

        /// <summary>
        /// Help method to avoid the selection to go out of bounds
        /// </summary>
        /// <returns></returns>
        internal bool NotAtTop()
        {
            return selectedMenuButton > 0;        
        }

        /// <summary>
        /// Help method to avoid the selection to go out of bounds
        /// </summary>
        /// <returns></returns>
        internal Boolean NotAtBottom()
        {
            return selectedMenuButton < menuButtons.Count - 1;
        }

        /// <summary>
        /// Gets the selected button
        /// </summary>
        /// <returns></returns>
        internal MenuButton GetSelectedButton()
        {
            return menuButtons.ElementAt(selectedMenuButton);
        }
    }
}
