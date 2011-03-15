using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    

    class MenuManager
    {
        private ContentManager contentManager;
        // Holds the name of the menu the menu-manager is currently working on
        private string activeMenu = "mainMenu";
        private Menu currentMenu;
        private MenuButton selectedMenuButton;
        private Boolean actionPerformed;

        private Menu mainMenu;

        #region testCode
        KeyboardState newState;
        KeyboardState oldState;
        #endregion

        public MenuManager()
        {
            actionPerformed = false;
            #region TestCode
            activeMenu = "mainMenu";
            #endregion
        }

        public MenuManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            this.CreateMenu("MainMenu");
        }


        
        public Menu CreateMenu(string menuName)
        {
            switch (menuName)
            {
                case "MainMenu":
                    mainMenu = new Menu("menuBackground", "MainMenu", new Rectangle(0,0,1280,720));
                    mainMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
                    mainMenu.AddMenuButton(new MenuButton(@"Sprites/MenuButtons/newGame", new Vector2(390,300), contentManager));
                    mainMenu.AddMenuButton(new MenuButton(@"Sprites/MenuButtons/help", new Vector2(390, 450), contentManager));
                    mainMenu.AddMenuButton(new MenuButton(@"Sprites/MenuButtons/quit", new Vector2(390, 600), contentManager));
                    return mainMenu;
            }
            return null;
        }

        public void Update(GameTime gameTime)
        {
            // Checks which menu the menu-manager is currently working on
            if ( activeMenu.Equals("mainMenu")) currentMenu = mainMenu;

            // Checks that a menu is currently active and a menu-action has not been requested
            if (!(currentMenu == null) && !actionPerformed) listenToInput(gameTime);
            
        }

        private void listenToInput(GameTime gameTime)
        {
        // Checks which menuButton is pressed and invokes the right method for it
        // ExecutePressedMenuButton();

            newState = Keyboard.GetState();
           

            if (newState.IsKeyDown(Keys.Down))
            {
                if (currentMenu.notAtBottom() && !oldState.IsKeyDown(Keys.Down))
                {
                    currentMenu.changeSelectionDown();
                }

            }
            else if (newState.IsKeyDown(Keys.Up))
            {
                if (currentMenu.notAtTop() && !oldState.IsKeyDown(Keys.Up))
                {
                    currentMenu.changeSelectionUp();
                }
            }

            else if (newState.IsKeyDown(Keys.Enter))
            {
                if (!oldState.IsKeyDown(Keys.Enter))
                {
                    selectedMenuButton = currentMenu.getSelectedButton();
                    selectedMenuButton.setButtonToPressed();
                    performAction(gameTime);
                }
            }
            
            oldState = newState;
        }


        // Method to perform the action of the button of choice
        private void performAction(GameTime gameTime)
        {
            actionPerformed = true;

            Timer timer = new Timer(500);
            timer.TimeEndedEvent += new TimerDelegate(performAction);
            timer.Start();
        }

        private void performAction()
        {

            actionPerformed = false;
            selectedMenuButton.setButtonToNotPressed();
            // TODO
            // Add actions for each button

            if (selectedMenuButton.getAssetName() == "MenuButtons/newGame")
            {
                // Action for "New game"
                Console.WriteLine("New game stuff");
            }
            else if (selectedMenuButton.getAssetName() == "MenuButtons/help")
            {
                // Action for help
                Console.WriteLine("help stuff");
            }

            else if (selectedMenuButton.getAssetName() == "MenuButtons/quit") Environment.Exit(0);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mainMenu.Draw(spriteBatch);
        }
    }  
}
