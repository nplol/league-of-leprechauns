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

        SpriteFont mainFont;
        SpriteFont menuInfoFont;
        SpriteFont header1;
        SpriteFont header2;


        public MenuManager(ContentManager contentManager)
        {
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
            mainMenu.AddMenuText(new MenuText(mainTitleOne, new Vector2(490, 20), 20, 20, header1, Color.Black));
            mainMenu.AddMenuText(new MenuText(mainTitleTwo, new Vector2(370, 80), 20, 20, header2, Color.Black));
            mainMenu.AddMenuButton(new MenuButton(mainNewGame, new Vector2(600,220), contentManager, newGameArrow));
            mainMenu.AddMenuButton(new MenuButton(mainHelp, new Vector2(600, 280), contentManager, helpArrow));
            mainMenu.AddMenuButton(new MenuButton(mainQuit, new Vector2(605, 340), contentManager, exitArrow));
                               
            mainMenuHelp = new Menu("menuBackground", new Rectangle(0,0,1280,720));
            mainMenuHelp.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            mainMenuHelp.AddMenuText(new MenuText(mainTitleOne, new Vector2(490, 20), 20, 20, header1, Color.Black));
            mainMenuHelp.AddMenuText(new MenuText(mainTitleTwo, new Vector2(370, 80), 20, 20, header2, Color.Black));
            mainMenuHelp.AddMenuButton(new MenuButton(helpBack, new Vector2(605, 340), contentManager, backArrow));
            mainMenuHelp.AddMenuImage(new MenuImage("Sprites/MenuButtons/infoBox1",new Vector2(20,200),contentManager));
            mainMenuHelp.AddMenuImage(new MenuImage("Sprites/MenuButtons/infoBox2", new Vector2(850, 200), contentManager));

            pauseMenu = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            pauseMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            pauseMenu.AddMenuButton(new MenuButton(pauseResumeGame, new Vector2(600, 220), contentManager, backToGameArrow));
            pauseMenu.AddMenuButton(new MenuButton(pauseHelp, new Vector2(600, 280), contentManager, helpArrow));
            pauseMenu.AddMenuButton(new MenuButton(pauseExitToMainMenu, new Vector2(605, 340), contentManager, backArrow));

            pauseMenuHelp = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            pauseMenuHelp.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            pauseMenuHelp.AddMenuButton(new MenuButton(pauseHelpBack, new Vector2(600, 340), contentManager, backToPauseArrow));
            pauseMenuHelp.AddMenuImage(new MenuImage("Sprites/MenuButtons/infoBox1", new Vector2(20, 200), contentManager));
            pauseMenuHelp.AddMenuImage(new MenuImage("Sprites/MenuButtons/infoBox2", new Vector2(850, 200), contentManager));

            areYouSureBox = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            areYouSureBox.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            areYouSureBox.AddMenuText(new MenuText(areYouSure, new Vector2(600, 220), 20, 40, mainFont, Color.Black));
            areYouSureBox.AddMenuButton(new MenuButton(yes, new Vector2(600, 280), contentManager, yesArrow));
            areYouSureBox.AddMenuButton(new MenuButton(no, new Vector2(600, 340), contentManager, noArrow));

            endMenu = new Menu("pauseBackground", new Rectangle(0, 0, 1280, 720));
            endMenu.LoadContent(this.contentManager, @"Sprites/Backgrounds/mainBackground");
            endMenu.AddMenuText(new MenuText(endGameOver, new Vector2(500, 148), 22, 40, mainFont, Color.Black));
            endMenu.AddMenuText(new MenuText(endGameTryAgain, new Vector2(500, 188), 22, 40, mainFont, Color.Black));
            endMenu.AddMenuButton(new MenuButton(endYes, new Vector2(600, 280), contentManager, endYesArrow));
            endMenu.AddMenuButton(new MenuButton(endNo, new Vector2(600, 340), contentManager, endNoArrow));

                

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
                //selectedMenuButton.setButtonToPressed();
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
                LeagueOfLeprechauns.GetInstance.NewGame();
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
            else if (selectedMenuButton.getAssetName() == endYes && activeMenu == Menus.END_GAME_MENU)
            {
                LeagueOfLeprechauns.GetInstance.RestartLevel();
            }
            else if (selectedMenuButton.getAssetName() == endNo && activeMenu == Menus.END_GAME_MENU)
            {
                activeMenu = Menus.MAIN_MENU;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentMenu.Draw(spriteBatch);
        }
    }  
}
