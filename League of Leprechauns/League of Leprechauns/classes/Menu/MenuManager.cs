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
        private string activeMenu;
        private Menu currentMenu;
        private MenuButton selectedMenuButton;
        private Boolean actionPerformed;


        #region TestCode
        private Menu mainMenu;
        private Menu helpMenu;
               
        KeyboardState newState;
        KeyboardState oldState;

        // list of buttons in different menu
        private string mainNewGame = "New Game";
        private string mainHelp = "Help";
        private string mainQuit = "Quit";
        private string helpBack = "Back";
        private string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private string helpText = "Herro! You can jump with space and that's pretty cool";
        SpriteFont infoText;
        #endregion


        public MenuManager(ContentManager contentManager)
        {
            #region TestCode
            activeMenu = "helpMenu";
                infoText = contentManager.Load<SpriteFont>("Arial");
            #endregion
            
            this.contentManager = contentManager;
            this.BuildMenus();
      
           

        }


         
        public void BuildMenus()
        {
            #region TestCode
            mainMenu = new Menu("menuBackground", new Rectangle(0,0,1280,720));
                mainMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
                mainMenu.AddMenuButton(new MenuButton(mainNewGame, new Vector2(390,300), contentManager));
                mainMenu.AddMenuButton(new MenuButton(mainHelp, new Vector2(390, 450), contentManager));
                mainMenu.AddMenuButton(new MenuButton(mainQuit, new Vector2(390, 600), contentManager));
                mainMenu.AddMenuText(new MenuText(loremIpsum, new Vector2(50,200), 20, 22, infoText, Color.Black));
                               
                helpMenu = new Menu("menuBackground", new Rectangle(0,0,1280,720));
                helpMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
                helpMenu.AddMenuButton(new MenuButton(helpBack, new Vector2(390, 600), contentManager));
                helpMenu.AddMenuText(new MenuText(helpText, new Vector2(440, 300), 22, 22, infoText, Color.Black));
                helpMenu.AddMenuImage(new MenuImage(@"Sprites/Characters/fluffernutterProto", new Vector2(50, 100), contentManager));
            #endregion
        }
             

            

        public void Update(GameTime gameTime)
        {
            // Checks which menu the menu-manager is currently working on
            if ( activeMenu.Equals("mainMenu")) currentMenu = mainMenu;
            else if (activeMenu.Equals("helpMenu")) currentMenu = helpMenu;

            // Checks that a menu is currently active and a menu-action has not been requested
            if (!(currentMenu == null) && !actionPerformed) listenToInput(gameTime);
            
        }

       
        private void listenToInput(GameTime gameTime)
        {
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


        /// <summary>
        /// Performs an action for the selected button using performAction()
        /// </summary>
        /// <param name="gameTime"></param>
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

            if (selectedMenuButton.getAssetName() == mainNewGame)
            {
                // Action for "New game"
                Console.WriteLine("New game stuff");
            }
            else if (selectedMenuButton.getAssetName() == mainHelp)
            {
                // Action for help
                Console.WriteLine("help stuff");
                activeMenu = "helpMenu";
            }

            else if (selectedMenuButton.getAssetName() == mainQuit) Environment.Exit(0);

            else if (selectedMenuButton.getAssetName() == helpBack)
            {
                // Action for help
                Console.WriteLine("back stuff");
                activeMenu = "mainMenu";
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentMenu.Draw(spriteBatch);
        }
    }  
}
