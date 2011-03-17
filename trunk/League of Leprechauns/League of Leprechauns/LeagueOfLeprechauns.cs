using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using LoL.Content;

namespace LoL
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class LeagueOfLeprechauns : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameState gameState;
        GameManager gameManager;
        MenuManager menuManager;

        public static SpriteFont arial;

        public LeagueOfLeprechauns()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = Settings.WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = Settings.WINDOW_WIDTH;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GlobalVariables.GraphicsDevice = GraphicsDevice;
            GlobalVariables.ContentManager = Content;
            menuManager = new MenuManager(Content);
            gameManager = new GameManager(Content);
            gameState = GameState.PLAYING;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            arial = Content.Load<SpriteFont>(@"Arial");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Timer.Update(gameTime);
            InputManager.GetInstance.Update(gameTime);

            switch (gameState)
            {
                case GameState.PLAYING:
                    gameManager.Update(gameTime);
                    break;
                case GameState.PAUSED:
                    break;
                case GameState.DEAD:
                    break;
                case GameState.GAME_OVER:
                    break;
                case GameState.MENU:
                    menuManager.Update(gameTime);
                    break;
                default:
                    break;
            }

            Timer.RemoveInactiveTimers();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.PLAYING:
                    gameManager.Draw(spriteBatch);
                    break;
                case GameState.PAUSED:
                    break;
                case GameState.DEAD:
                    break;
                case GameState.GAME_OVER:
                    break;
                case GameState.MENU:
                    menuManager.Draw(spriteBatch);
                    break;
                default:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}