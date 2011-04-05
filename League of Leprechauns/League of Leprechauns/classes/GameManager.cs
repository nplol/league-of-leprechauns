﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace LoL
{
    class GameManager
    {
        Camera camera;
        LevelManager levelManager;
        HUD hud;

        FlufferNutter flufferNutter;
        CabbageLips cabbageLips;

        public GameManager(ContentManager content)
        {
            levelManager = LevelManager.GetInstance;

            camera = Camera.GetInstance();

            LoadNextLevel();

            //make sure fluffernutter and cabbagelips is not null when instanciating HUD
            hud = new HUD();
        }
        
        /// <summary>
        /// Loads the next level. 
        /// </summary>
        public void LoadNextLevel()
        {
            if (levelManager.CurrentLevel == levelManager.LastLevel)
            {
                //Game is over
            }
            //Reset everything and load next level
            else
            {
                Timer.RemoveAllTimers();
                levelManager.ChangeLevel(levelManager.CurrentLevel + 1);
                camera.Reset();
                flufferNutter = ActorManager.GetFlufferNutterInstance;
                cabbageLips = ActorManager.GetCabbageLipsInstance;
            }
        }

        public void ReloadCurrentLevel()
        {
            Timer.RemoveAllTimers();
            levelManager.ChangeLevel(levelManager.CurrentLevel);
            camera.Reset();
            flufferNutter = ActorManager.GetFlufferNutterInstance;
            cabbageLips = ActorManager.GetCabbageLipsInstance;
            flufferNutter.resetCharacter();
            cabbageLips.resetCharacter();

        }

        /// <summary>
        /// Core method of the game.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

            //Applying friction and gravity to all characters.
            PhysicsEngine.GetInstance.ApplyForces();
         
            // Collision detector based upon gravity etc.
            CollisionDetector.DetectCollisions(ActorManager.getListOfActiveActors());
            
            // Input from the user.
            HandleInput();
           
            // Updating each actor, making the NPCs move as well as animations play out.

            ActorManager.Update(gameTime);
            

            if (CheckIsGameOver())
                LeagueOfLeprechauns.GetInstance.GameOver();


            camera.Update(gameTime);
          

            hud.Update(gameTime);    
        }

        private bool CheckIsGameOver()
        {
            if (flufferNutter.IsDead() && cabbageLips.IsDead())
                return true;

            return false;
        }

        private void HandleInput()
        {
            if (InputManager.GetInstance.IsButtonDown(Buttons.DPadLeft, PlayerIndex.One))
            {
                flufferNutter.Move(Direction.LEFT);
            }

            if (InputManager.GetInstance.IsButtonDown(Buttons.DPadRight, PlayerIndex.One))
            {
                flufferNutter.Move(Direction.RIGHT);
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.A))
            {
                flufferNutter.Move(Direction.LEFT);
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.D))
            {
                flufferNutter.Move(Direction.RIGHT);
            }
            if (InputManager.GetInstance.IsKeyDown(Keys.W))
            {
                flufferNutter.Jump();
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.LeftControl))
            {
                flufferNutter.PerformAbility(AbilityNumber.FIRST);
            }

            /*if (InputManager.GetInstance.IsKeyDown(Keys.LeftAlt))
            {
                flufferNutter.PerformAbility(AbilityNumber.SECOND);
            }*/

            if (InputManager.GetInstance.IsKeyDown(Keys.RightControl))
            {
                cabbageLips.PerformAbility(AbilityNumber.FIRST);
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.RightShift))
            {
                cabbageLips.PerformAbility(AbilityNumber.SECOND);
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.Left))
            {
                cabbageLips.Move(Direction.LEFT);
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.Right))
            {
                cabbageLips.Move(Direction.RIGHT);
            }

            if (InputManager.GetInstance.IsKeyPress(Keys.Up))
            {
                cabbageLips.Jump();
            }
            if (InputManager.GetInstance.IsKeyPress(Keys.Escape))
            {
                LeagueOfLeprechauns.GetInstance.PauseGame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //TODO: Flytte bakgrunn til en annen klasse?
            spriteBatch.Draw(levelManager.CurrentBackground, Vector2.Zero, Color.White);

            ActorManager.Draw(spriteBatch, camera);

            hud.Draw(spriteBatch);

            camera.DrawDebug(spriteBatch);
        }

        internal void NewGame()
        {
            levelManager.ChangeLevel(1);
            camera.Reset();
            flufferNutter = ActorManager.GetFlufferNutterInstance;
            cabbageLips = ActorManager.GetCabbageLipsInstance;
            flufferNutter.resetCharacter();
            cabbageLips.resetCharacter();
        }
    }
}