
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of the game manager.
    /// </summary>
    class GameManager
    {
        private Camera camera;
        private LevelManager levelManager;
        private HUD hud;

        private FlufferNutter flufferNutter;
        private CabbageLips cabbageLips;

        /// <summary>
        /// Instanciates the game manager.
        /// </summary>
        public GameManager()
        {
            levelManager = LevelManager.GetInstance;
            camera = Camera.GetInstance();
            NewGame();
            hud = new HUD();
        }

        /// <summary>
        /// Resets the current level
        /// </summary>
        public void ReloadCurrentLevel()
        {
            Timer.RemoveAllTimers();
            levelManager.ChangeLevel(levelManager.CurrentLevel);
            camera.Reset();
            flufferNutter = ActorManager.GetFlufferNutterInstance;
            cabbageLips = ActorManager.GetCabbageLipsInstance;
            flufferNutter.respawnCharacter();
            cabbageLips.respawnCharacter();
        }

        /// <summary>
        /// Core method of the game play. First, the physics engine applies forces to each acive actor,
        /// and then the collision dector dectecs collisions based upon the movements caused by these forces.
        /// After this has been done, the actor manager is updated which ressonates in updating the active
        /// actors as well, updating their positions based upon user input from the HanldeInput method.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            PhysicsEngine.GetInstance.ApplyForces();
         
            CollisionDetector.DetectCollisions(ActorManager.GetListOfActiveActors());
            
            HandleInput();

            ActorManager.Update(gameTime);
            
            if (CheckIsGameOver())
                LeagueOfLeprechauns.GetInstance.GameOver();

            if(Settings.BOSS_LEVELS.Contains(levelManager.CurrentLevel))
                camera.Update(gameTime, true);
            else
                camera.Update(gameTime, false);
        }

        private bool CheckIsGameOver()
        {
            if (flufferNutter.IsDead() && cabbageLips.IsDead())
                return true;

            return false;
        }

        /// <summary>
        /// Handles input from the users calls the respective methods based upon
        /// the input.
        /// </summary>
        private void HandleInput()
        {

            //Fluffernutter PC
            if (InputManager.GetInstance.IsKeyDown(Keys.A))
            {
                flufferNutter.Move(Direction.LEFT);
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.D))
            {
                flufferNutter.Move(Direction.RIGHT);
            }
            if (InputManager.GetInstance.IsKeyPress(Keys.W))
            {
                flufferNutter.Jump();
            }

            if (InputManager.GetInstance.IsKeyPress(Keys.LeftControl))
            {
                flufferNutter.PerformAbility(AbilityNumber.FIRST);
            }

            if (InputManager.GetInstance.IsKeyPress(Keys.LeftShift))
            {
                flufferNutter.PerformAbility(AbilityNumber.SECOND);
            }

            //CabbageLips PC
            if (InputManager.GetInstance.IsKeyPress(Keys.RightControl))
            {
                cabbageLips.PerformAbility(AbilityNumber.FIRST);
            }

            if (InputManager.GetInstance.IsKeyPress(Keys.RightShift))
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

            //Fluffernutter XBOX
            if (InputManager.GetInstance.IsButtonDown(Buttons.DPadLeft, PlayerIndex.Two))
            {
                flufferNutter.Move(Direction.LEFT);
            }

            if (InputManager.GetInstance.IsButtonDown(Buttons.DPadRight, PlayerIndex.Two))
            {
                flufferNutter.Move(Direction.RIGHT);
            }

            if (InputManager.GetInstance.IsButtonPress(Buttons.A, PlayerIndex.Two))
            {
                flufferNutter.Jump();
            }

            if (InputManager.GetInstance.IsButtonPress(Buttons.X, PlayerIndex.Two))
            {
                flufferNutter.PerformAbility(AbilityNumber.FIRST);
            }

            if (InputManager.GetInstance.IsButtonPress(Buttons.Y, PlayerIndex.Two))
            {
                flufferNutter.PerformAbility(AbilityNumber.SECOND);
            }

            //Cabbagelips XBOX
            if (InputManager.GetInstance.IsButtonDown(Buttons.DPadLeft, PlayerIndex.One))
            {
                flufferNutter.Move(Direction.LEFT);
            }

            if (InputManager.GetInstance.IsButtonDown(Buttons.DPadRight, PlayerIndex.One))
            {
                flufferNutter.Move(Direction.RIGHT);
            }

            if (InputManager.GetInstance.IsButtonPress(Buttons.A, PlayerIndex.One))
            {
                flufferNutter.Jump();
            }

            if (InputManager.GetInstance.IsButtonPress(Buttons.X, PlayerIndex.One))
            {
                flufferNutter.PerformAbility(AbilityNumber.FIRST);
            }

            if (InputManager.GetInstance.IsButtonPress(Buttons.Y, PlayerIndex.One))
            {
                flufferNutter.PerformAbility(AbilityNumber.SECOND);
            }

            //Pause game XBOX and PC
            if (InputManager.GetInstance.IsKeyPress(Keys.Escape))
            {
                LeagueOfLeprechauns.GetInstance.PauseGame();
            }
            if (InputManager.GetInstance.IsButtonPress(Buttons.Start, PlayerIndex.One))
            {
                LeagueOfLeprechauns.GetInstance.PauseGame();
            }
            if (InputManager.GetInstance.IsButtonPress(Buttons.Start, PlayerIndex.Two))
            {
                LeagueOfLeprechauns.GetInstance.PauseGame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(levelManager.CurrentBackground, Vector2.Zero, Color.White);

            ActorManager.Draw(spriteBatch, camera);

            hud.Draw(spriteBatch);
        }

        /// <summary>
        /// Starts a new game of Leage of Leprechauns, will you be able to beat it this time?
        /// </summary>
        public void NewGame()
        {
            levelManager.ChangeLevel(0);
            camera.Reset();
            flufferNutter = ActorManager.GetFlufferNutterInstance;
            cabbageLips = ActorManager.GetCabbageLipsInstance;

            flufferNutter.resetCharacter();
            cabbageLips.resetCharacter();
        }
    }
}