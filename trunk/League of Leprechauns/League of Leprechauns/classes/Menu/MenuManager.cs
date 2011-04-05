using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    internal enum Menus
    {
        MAIN_MENU,
        MAIN_MENU_HELP,
        PAUSE_MENU,
        PAUSE_MENU_HELP,
        ARE_YOU_SURE,
        END_GAME_MENU,
        GAME_WON
    }

    class MenuManager
    {
        /// <summary>
        /// enum class holding the different menus
        /// 
        /// </summary>
       

        private ContentManager contentManager;
        private Menus activeMenu;
        private Menus previousActiveMenu;
        private Menu currentMenu;
        private MenuButton selectedMenuButton;
        private Boolean actionPerformed;

        #region mainMenu
        private Menu mainMenu;
        private Texture2D newGameArrow;
        private Texture2D helpArrow;
        private Texture2D exitArrow;
        private string mainTitleOne = "LEAGUE OF";
        private string mainTitleTwo = "LEPRECHAUNS";
        private string mainNewGame = "PLAY";
        private string mainHelp = "HELP";
        private string mainQuit = "EXIT";
        #endregion

        #region helpMenu
        private Menu mainMenuHelp;
        private Texture2D backArrow;
        private string helpBack = "BACK";
        #endregion

        #region pauseMenu
        private Menu pauseMenu;
        private Texture2D backToGameArrow;
        private string pauseResumeGame = "Resume Game";
        private string pauseHelp = "Help";
        private string pauseExitToMainMenu = "Exit To Main Menu";
        #endregion

        #region endMenu
        private Menu endMenu;
        private Texture2D endYesArrow;
        private Texture2D endNoArrow;
        private string endGameOver = "Game Over";
        private string endGameTryAgain = "Try again?";
        private string endYes = "Yes";
        private string endNo = "No";
        #endregion

        #region pauseHelpMenu
        private Menu pauseMenuHelp;
        private Texture2D backToPauseArrow;
        private string pauseHelpBack = "Back";
        #endregion

        #region areYouSureBox
        private Menu areYouSureBox;
        private Texture2D yesArrow;
        private Texture2D noArrow;
        private string areYouSure = "Are you sure?";
        private string yes = "Yes";
        private string no = "No";
        #endregion

        #region gameWon
        private Menu gameWon;
        private string won = "Hurraay, you've won!";
        private string wonExitToMainMenu = "Return Main Menu";
        #endregion

        SpriteFont mainFont;
        SpriteFont menuInfoFont;
        SpriteFont header1;
        SpriteFont header2;

        /// <summary>
        /// Builds all the menus.
        /// </summary>
        public MenuManager()
        {
            this.contentManager = GlobalVariables.ContentManager;
            activeMenu = Menus.MAIN_MENU;
            mainFont = contentManager.Load<SpriteFont>("Sprites/SpriteFonts/MainFont");
            menuInfoFont = contentManager.Load<SpriteFont>("Sprites/SpriteFonts/MenuInfoFont");
            header1 = contentManager.Load<SpriteFont>("Sprites/SpriteFonts/Header1");
            header2 = contentManager.Load<SpriteFont>("Sprites/SpriteFonts/Header2");
            newGameArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/newGameArrow");
            helpArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/helpArrow");
            exitArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/exitArrow");
            backArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/backArrow");
            backToGameArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/backToGameArrow");
            backToPauseArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/backToPauseArrow");
            yesArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/yesArrow");
            noArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/noArrow");
            endYesArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/endYesArrow");
            endNoArrow = contentManager.Load<Texture2D>("Sprites/MenuButtons/endNoArrow");

            this.BuildMenus();
        }

        /// <summary>
        /// sets the Menu given as a parameter to activeMenu
        /// </summary>
        /// <param name="menu"></param>
        internal void SetActiveMenu(Menus menu)
        {
            this.activeMenu = menu;
        }

        /// <summary>
        /// builds all the menus used in the game
        /// </summary>
        private void BuildMenus()
        {
            mainMenu = new Menu("menuBackground", new Rectangle(0,0,1280,720));
            mainMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            mainMenu.AddMenuText(new MenuText(mainTitleOne, new Vector2(490, 20), 20, 20, header1, Color.Black));
            mainMenu.AddMenuText(new MenuText(mainTitleTwo, new Vector2(370, 80), 20, 20, header2, Color.Black));
            mainMenu.AddMenuButton(new MenuButton(mainNewGame, new Vector2(600,220), newGameArrow));
            mainMenu.AddMenuButton(new MenuButton(mainHelp, new Vector2(600, 280), helpArrow));
            mainMenu.AddMenuButton(new MenuButton(mainQuit, new Vector2(605, 340), exitArrow));
                               
            mainMenuHelp = new Menu("menuBackground", new Rectangle(0,0,1280,720));
            mainMenuHelp.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            mainMenuHelp.AddMenuText(new MenuText(mainTitleOne, new Vector2(490, 20), 20, 20, header1, Color.Black));
            mainMenuHelp.AddMenuText(new MenuText(mainTitleTwo, new Vector2(370, 80), 20, 20, header2, Color.Black));
            mainMenuHelp.AddMenuButton(new MenuButton(helpBack, new Vector2(605, 340), backArrow));
            mainMenuHelp.AddMenuImage(new MenuImage("Sprites/MenuButtons/infoBox1",new Vector2(20,200)));
            mainMenuHelp.AddMenuImage(new MenuImage("Sprites/MenuButtons/infoBox2", new Vector2(850, 200)));

            pauseMenu = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            pauseMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            pauseMenu.AddMenuButton(new MenuButton(pauseResumeGame, new Vector2(600, 220), backToGameArrow));
            pauseMenu.AddMenuButton(new MenuButton(pauseHelp, new Vector2(600, 280), helpArrow));
            pauseMenu.AddMenuButton(new MenuButton(pauseExitToMainMenu, new Vector2(605, 340), backArrow));

            pauseMenuHelp = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            pauseMenuHelp.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            pauseMenuHelp.AddMenuButton(new MenuButton(pauseHelpBack, new Vector2(600, 340), backToPauseArrow));
            pauseMenuHelp.AddMenuImage(new MenuImage("Sprites/MenuButtons/infoBox1", new Vector2(20, 200)));
            pauseMenuHelp.AddMenuImage(new MenuImage("Sprites/MenuButtons/infoBox2", new Vector2(850, 200)));

            areYouSureBox = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            areYouSureBox.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            areYouSureBox.AddMenuText(new MenuText(areYouSure, new Vector2(600, 220), 20, 40, mainFont, Color.Black));
            areYouSureBox.AddMenuButton(new MenuButton(yes, new Vector2(600, 280), yesArrow));
            areYouSureBox.AddMenuButton(new MenuButton(no, new Vector2(600, 340), noArrow));

            endMenu = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            endMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            endMenu.AddMenuText(new MenuText(endGameOver, new Vector2(500, 148), 22, 40, mainFont, Color.Black));
            endMenu.AddMenuText(new MenuText(endGameTryAgain, new Vector2(500, 188), 22, 40, mainFont, Color.Black));
            endMenu.AddMenuButton(new MenuButton(endYes, new Vector2(600, 280), endYesArrow));
            endMenu.AddMenuButton(new MenuButton(endNo, new Vector2(600, 340), endNoArrow));

            gameWon = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            gameWon.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            gameWon.AddMenuText(new MenuText(won, new Vector2(500, 148), 22, 40, mainFont, Color.Black));
            gameWon.AddMenuButton(new MenuButton(wonExitToMainMenu, new Vector2(600, 340), backToGameArrow));

        }
             
        /// <summary>
        /// Checks which menu is active now and sets the currentMenu to activeMenu
        /// If no changes has been in this tick no changes are made
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Checks which menu the menu-manager is currently working on
            if (activeMenu == Menus.MAIN_MENU) currentMenu = mainMenu;
            else if (activeMenu == Menus.MAIN_MENU_HELP) currentMenu = mainMenuHelp;
            else if (activeMenu == Menus.PAUSE_MENU) currentMenu = pauseMenu;
            else if (activeMenu == Menus.PAUSE_MENU_HELP) currentMenu = pauseMenuHelp;
            else if (activeMenu == Menus.ARE_YOU_SURE) currentMenu = areYouSureBox;
            else if (activeMenu == Menus.END_GAME_MENU) currentMenu = endMenu;
            else if (activeMenu == Menus.GAME_WON) currentMenu = gameWon;

            // Checks that a menu is currently active and a menu-action has not been requested
            if (!(currentMenu == null) && !actionPerformed) HandleInput(gameTime);
            
        }

        /// <summary>
        /// Checks for user inputs and updates the menu accordingly
        /// If Enter is pressed, performAction is called
        /// </summary>
        /// <param name="gameTime"></param>
        private void HandleInput(GameTime gameTime)
        {  
            if (InputManager.GetInstance.IsKeyPress(Keys.Down) || InputManager.GetInstance.IsButtonPress(Buttons.DPadDown, PlayerIndex.One))
            {
                currentMenu.ChangeSelectionDown();
            }
            else if (InputManager.GetInstance.IsKeyPress(Keys.Up) || InputManager.GetInstance.IsButtonPress(Buttons.DPadUp, PlayerIndex.One))
            {   
                currentMenu.ChangeSelectionUp();
            }

            else if (InputManager.GetInstance.IsKeyPress(Keys.Enter) || InputManager.GetInstance.IsButtonPress(Buttons.X, PlayerIndex.One))
            {
                selectedMenuButton = currentMenu.GetSelectedButton();
                PerformAction(gameTime);
            }
        }


        /// <summary>
        /// Performs an action for the selected button using performAction()
        /// A timer is set to 150ms, before performAction is called
        /// </summary>
        /// <param name="gameTime"></param>
        private void PerformAction(GameTime gameTime)
        {
            actionPerformed = true;
                    
            Timer timer = new Timer(150);
            timer.TimeEndedEvent += new TimerDelegate(PerformAction);
            timer.Start();
        }
        
        /// <summary>
        /// checks which button is pressed and performs accordingly
        /// </summary>
        private void PerformAction()
        {
            actionPerformed = false;
            if (selectedMenuButton.GetAssetName() == mainNewGame)
            {
                // Action for "New game"
                LeagueOfLeprechauns.GetInstance.NewGame();
            }
            else if (selectedMenuButton.GetAssetName() == mainHelp)
            {
                // Action for help
                previousActiveMenu = Menus.MAIN_MENU;
                activeMenu = Menus.MAIN_MENU_HELP;
            }

            else if (selectedMenuButton.GetAssetName() == mainQuit)
            {
                Environment.Exit(0);
            }

            else if (selectedMenuButton.GetAssetName() == helpBack && previousActiveMenu == Menus.MAIN_MENU)
            {
                // Action for help
                activeMenu = Menus.MAIN_MENU;
            }

            else if (selectedMenuButton.GetAssetName() == pauseResumeGame)
            {
                LeagueOfLeprechauns.GetInstance.ResumeGame();
            }

            else if (selectedMenuButton.GetAssetName() == pauseHelp)
            {
                previousActiveMenu = Menus.PAUSE_MENU;
                activeMenu = Menus.PAUSE_MENU_HELP;
            }

            else if (selectedMenuButton.GetAssetName() == pauseExitToMainMenu)
            {
                activeMenu = Menus.ARE_YOU_SURE;
            }

            else if (selectedMenuButton.GetAssetName() == pauseHelpBack && previousActiveMenu == Menus.PAUSE_MENU)
            {
                activeMenu = Menus.PAUSE_MENU;
            }
            else if (selectedMenuButton.GetAssetName() == yes && activeMenu == Menus.ARE_YOU_SURE)
            {
                activeMenu = Menus.MAIN_MENU;
            }
            else if (selectedMenuButton.GetAssetName() == no && activeMenu == Menus.ARE_YOU_SURE)
            {
                activeMenu = Menus.PAUSE_MENU;
            }
            else if (selectedMenuButton.GetAssetName() == endYes && activeMenu == Menus.END_GAME_MENU)
            {
                LeagueOfLeprechauns.GetInstance.RestartLevel();
            }
            else if (selectedMenuButton.GetAssetName() == endNo && activeMenu == Menus.END_GAME_MENU)
            {
                activeMenu = Menus.MAIN_MENU;
            }
            else if (selectedMenuButton.GetAssetName() == wonExitToMainMenu && activeMenu == Menus.GAME_WON)
            {
                activeMenu = Menus.MAIN_MENU;
            }
        }

        /// <summary>
        /// Draws the currentMenu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            currentMenu.Draw(spriteBatch);
        }
    }  
}
