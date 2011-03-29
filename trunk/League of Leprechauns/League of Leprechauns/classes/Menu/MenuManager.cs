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

        internal enum Menus
        { 
            MAIN_MENU,
            MAIN_MENU_HELP,
            PAUSE_MENU,
            PAUSE_MENU_HELP,
            ARE_YOU_SURE,
            END_GAME_MENU,
        }

        private ContentManager contentManager;
        private Menus activeMenu;
        private Menus previousActiveMenu;
        private Menu currentMenu;
        private MenuButton selectedMenuButton;
        private Boolean actionPerformed;
        private LeagueOfLeprechauns leagueOfLeprechauns;

        #region mainMenu
        private Menu mainMenu;
        private string mainNewGame = "New Game";
        private string mainHelp = "Help";
        private string mainQuit = "Quit";
        #endregion

        #region helpMenu
        private Menu mainMenuHelp;
        private string helpBack = "Back";
        private string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private string helpText = "Herro! You can jump with space and that's pretty cool";
        #endregion

        #region pauseMenu
        private Menu pauseMenu;
        private string pauseResumeGame = "Resume Game";
        private string pauseHelp = "Help";
        private string pauseExitToMainMenu = "Exit To Main Menu";
        #endregion

        #region endMenu
        private Menu endMenu;
        private string endGameOver = "Game Over";
        private string endNewGame = "New Game";
        private string endExitToMainMenu = "Exit To Main Menu";
        private string endQuit = "Quit";
        #endregion

        #region pauseHelpMenu
        private Menu pauseMenuHelp;
        private string pauseHelpBack = "Back";
        #endregion

        #region areYouSureBox
        private Menu areYouSureBox;
        private string areYouSure = "Are you sure?";
        private string yes = "Yes";
        private string no = "No";
        #endregion

        SpriteFont buttonFont;
        SpriteFont menuInfoText;


        public MenuManager(ContentManager contentManager, LeagueOfLeprechauns leagueOfLeprechauns)
        {
            activeMenu = Menus.MAIN_MENU;
            buttonFont = contentManager.Load<SpriteFont>("Sprites/SpriteFonts/ButtonFont");
            menuInfoText = contentManager.Load<SpriteFont>("Sprites/SpriteFonts/MenuInfoText");

            this.leagueOfLeprechauns = leagueOfLeprechauns;
            this.contentManager = contentManager;
            this.BuildMenus();
        }

        internal void setActiveMenu(Menus menu)
        {
            this.activeMenu = menu;
        }


         
        public void BuildMenus()
        {
            mainMenu = new Menu("menuBackground", new Rectangle(0,0,1280,720));
            mainMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            mainMenu.AddMenuButton(new MenuButton(mainNewGame, new Vector2(390,300), contentManager));
            mainMenu.AddMenuButton(new MenuButton(mainHelp, new Vector2(390, 450), contentManager));
            mainMenu.AddMenuButton(new MenuButton(mainQuit, new Vector2(390, 600), contentManager));
            mainMenu.AddMenuText(new MenuText(loremIpsum, new Vector2(50,200), 20, 22, menuInfoText, Color.Black));
                               
            mainMenuHelp = new Menu("menuBackground", new Rectangle(0,0,1280,720));
            mainMenuHelp.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            mainMenuHelp.AddMenuButton(new MenuButton(helpBack, new Vector2(390, 600), contentManager));
            mainMenuHelp.AddMenuText(new MenuText(helpText, new Vector2(440, 300), 22, 22, menuInfoText, Color.Black));
            mainMenuHelp.AddMenuImage(new MenuImage(@"Sprites/Characters/fluffernutterAvatar", new Vector2(50, 100), contentManager));

            pauseMenu = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            pauseMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/pauseBackground");
            pauseMenu.AddMenuButton(new MenuButton(pauseResumeGame, new Vector2(390,300),contentManager));
            pauseMenu.AddMenuButton(new MenuButton(pauseHelp, new Vector2(390,450),contentManager));
            pauseMenu.AddMenuButton(new MenuButton(pauseExitToMainMenu, new Vector2(390,600),contentManager));
            pauseMenu.AddMenuText(new MenuText(loremIpsum, new Vector2(50, 200), 20, 22, menuInfoText, Color.Black));

            pauseMenuHelp = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            pauseMenuHelp.LoadContent(this.contentManager, @"Sprites/Backgrounds/pauseBackground");
            pauseMenuHelp.AddMenuButton(new MenuButton(pauseHelpBack, new Vector2(390, 600), contentManager));
            pauseMenuHelp.AddMenuText(new MenuText(helpText, new Vector2(440, 300), 22, 22, menuInfoText, Color.Black));
            pauseMenuHelp.AddMenuImage(new MenuImage(@"Sprites/Characters/fluffernutterAvatar", new Vector2(50, 100), contentManager));

            areYouSureBox = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            areYouSureBox.LoadContent(this.contentManager, @"Sprites/Backgrounds/pauseBackground");
            areYouSureBox.AddMenuText(new MenuText(areYouSure, new Vector2(390, 300), 20, 22, buttonFont, Color.Black));
            areYouSureBox.AddMenuButton(new MenuButton(yes, new Vector2(390, 450), contentManager));
            areYouSureBox.AddMenuButton(new MenuButton(no, new Vector2(390, 600), contentManager));

            endMenu = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            endMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/pauseBackground");
            endMenu.AddMenuText(new MenuText(endGameOver, new Vector2(390, 150), 20, 22, buttonFont, Color.Black));
            endMenu.AddMenuButton(new MenuButton(endNewGame, new Vector2(390, 300), contentManager));
            endMenu.AddMenuButton(new MenuButton(endExitToMainMenu, new Vector2(390, 450), contentManager));
            endMenu.AddMenuButton(new MenuButton(endQuit, new Vector2(390, 600), contentManager));

                

        }
             

            

        public void Update(GameTime gameTime)
        {
            // Checks which menu the menu-manager is currently working on
            if (activeMenu == Menus.MAIN_MENU) currentMenu = mainMenu;
            else if (activeMenu == Menus.MAIN_MENU_HELP) currentMenu = mainMenuHelp;
            else if (activeMenu == Menus.PAUSE_MENU) currentMenu = pauseMenu;
            else if (activeMenu == Menus.PAUSE_MENU_HELP) currentMenu = pauseMenuHelp;
            else if (activeMenu == Menus.ARE_YOU_SURE) currentMenu = areYouSureBox;
            else if (activeMenu == Menus.END_GAME_MENU) currentMenu = endMenu;

            // Checks that a menu is currently active and a menu-action has not been requested
            if (!(currentMenu == null) && !actionPerformed) listenToInput(gameTime);
            
        }

       
        private void listenToInput(GameTime gameTime)
        {  
            if (InputManager.GetInstance.IsKeyPress(Keys.Down) || InputManager.GetInstance.IsButtonPress(Buttons.DPadDown, PlayerIndex.One))
            {
                currentMenu.changeSelectionDown();
            }
            else if (InputManager.GetInstance.IsKeyPress(Keys.Up) || InputManager.GetInstance.IsButtonPress(Buttons.DPadUp, PlayerIndex.One))
            {   
                currentMenu.changeSelectionUp();
            }

            else if (InputManager.GetInstance.IsKeyPress(Keys.Enter) || InputManager.GetInstance.IsButtonPress(Buttons.X, PlayerIndex.One))
            {
                selectedMenuButton = currentMenu.getSelectedButton();
                selectedMenuButton.setButtonToPressed();
                performAction(gameTime);
            }
        }


        /// <summary>
        /// Performs an action for the selected button using performAction()
        /// </summary>
        /// <param name="gameTime"></param>
        private void performAction(GameTime gameTime)
        {
            actionPerformed = true;
                    
            Timer timer = new Timer(150);
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
                leagueOfLeprechauns.NewGame();
            }
            else if (selectedMenuButton.getAssetName() == mainHelp)
            {
                // Action for help
                previousActiveMenu = Menus.MAIN_MENU;
                activeMenu = Menus.MAIN_MENU_HELP;
            }

            else if (selectedMenuButton.getAssetName() == mainQuit)
            {
                Environment.Exit(0);
            }


            else if (selectedMenuButton.getAssetName() == helpBack && previousActiveMenu == Menus.MAIN_MENU)
            {
                // Action for help
                activeMenu = Menus.MAIN_MENU;
            }
 
            else if(selectedMenuButton.getAssetName() == pauseResumeGame)
            {
                LeagueOfLeprechauns.GetInstance.ResumeGame();
            }

            else if (selectedMenuButton.getAssetName() == pauseHelp)
            {
                previousActiveMenu = Menus.PAUSE_MENU;
                activeMenu = Menus.PAUSE_MENU_HELP;
            }

            else if (selectedMenuButton.getAssetName() == pauseExitToMainMenu)
            {
                activeMenu = Menus.ARE_YOU_SURE;
            }

            else if (selectedMenuButton.getAssetName() == pauseHelpBack && previousActiveMenu == Menus.PAUSE_MENU)
            {
                activeMenu = Menus.PAUSE_MENU;
            }
            else if (selectedMenuButton.getAssetName() == yes && activeMenu == Menus.ARE_YOU_SURE)
            {
                activeMenu = Menus.MAIN_MENU;
            }
            else if (selectedMenuButton.getAssetName() == no && activeMenu == Menus.ARE_YOU_SURE)
            {
                activeMenu = Menus.PAUSE_MENU;
            }
            else if (selectedMenuButton.getAssetName() == endNewGame && activeMenu == Menus.END_GAME_MENU)
            {
                leagueOfLeprechauns.NewGame();
            }
            else if (selectedMenuButton.getAssetName() == endExitToMainMenu && activeMenu == Menus.END_GAME_MENU)
            {
                activeMenu = Menus.MAIN_MENU;
            }
            else if (selectedMenuButton.getAssetName() == endQuit && activeMenu == Menus.END_GAME_MENU)
            {
                Environment.Exit(0);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentMenu.Draw(spriteBatch);
        }
    }  
}
