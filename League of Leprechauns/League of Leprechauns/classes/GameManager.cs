using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            levelManager = new LevelManager(content);

            camera = new Camera();

            hud = new HUD();
            LoadLevel();
        }
        
        //UNFINISHED. 
        public void LoadLevel()
        {
            if (levelManager.CurrentLevel == levelManager.LastLevel)
            {
                //Game is over
            }
            //Reset everything and load next level
            else
            {
                levelManager.ChangeLevel(levelManager.CurrentLevel + 1);
                camera.Reset();
                flufferNutter = ActorManager.GetFlufferNutterInstance();
                cabbageLips = ActorManager.GetCabbageLipsInstance();
            }
        }


        public void Update(GameTime gameTime)
        {
            PhysicsEngine.GetInstance.ApplyForces();
            
            //TODO: USE Move method instead of position
            if (InputManager.GetInstance.IsButtonDown(Buttons.DPadLeft, PlayerIndex.One))
            {
                flufferNutter.Move(Direction.LEFT);
            }

            if (InputManager.GetInstance.IsButtonDown(Buttons.DPadRight, PlayerIndex.One))
            {
                flufferNutter.Move(Direction.RIGHT); 
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.Left))
            {
                cabbageLips.Move(Direction.LEFT);
            }

            if (InputManager.GetInstance.IsKeyDown(Keys.Right))
            {
                cabbageLips.Move(Direction.RIGHT);
            }

            ActorManager.Update(gameTime);

            camera.Update(gameTime);

            hud.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //TODO: Flytte bakgrunn til en annen klasse?
            spriteBatch.Draw(levelManager.CurrentBackground, Vector2.Zero, Color.White);

            ActorManager.Draw(spriteBatch, camera);

            hud.Draw(spriteBatch);

            camera.DrawDebug(spriteBatch);
        }
    }
}