using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LoL
{

    public enum Direction { LEFT = -1, UP = -1, RIGHT = 1, DOWN = 1 }
    public class Camera
    {
        private Vector2 position, size;
        private int cameraSpeed;
        private FlufferNutter flufferNutter;
        private CabbageLips cabbageLips;

        private static Camera instance;

        public int CameraSpeed
        {
            get { return cameraSpeed; }
            set { cameraSpeed = value; } 
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public static Camera GetInstance()
        {
            if (instance == null)
            {
                instance = new Camera();
            }
            return instance;
        }

        private Camera()
        {
            position = new Vector2(0, 0);
            size = new Vector2(Settings.WINDOW_WIDTH, Settings.WINDOW_HEIGHT);
            cameraSpeed = Settings.PLAYER_INITIAL_SPEED;

            UpdateReferenceToPlayerCharacters();
        }

        /// <summary>
        /// Updates the references to FlufferNutter and CabbageLips
        /// </summary>
        private void UpdateReferenceToPlayerCharacters()
        {
            this.flufferNutter = ActorManager.GetFlufferNutterInstance();
            this.cabbageLips = ActorManager.GetCabbageLipsInstance();
        }

        /// <summary>
        /// Resets the camera's position.
        /// </summary>
        public void Reset()
        {
            position = Vector2.Zero;
            size = new Vector2(Settings.WINDOW_WIDTH, Settings.WINDOW_HEIGHT);
            UpdateReferenceToPlayerCharacters();
        }

        /// <summary>
        /// Updates the camera's position based on the position of the actors FlufferNutter and CabbageLips
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (flufferNutter != null || cabbageLips != null)
            {
                // Updating the horizontal position
                position.X = 0;
                position.X += flufferNutter.IsDead() ? 0 : flufferNutter.CurrentPosition.X;
                position.X += cabbageLips.IsDead() ? 0 : cabbageLips.CurrentPosition.X;
                position.X = (cabbageLips.IsDead() || flufferNutter.IsDead()) ? position.X : position.X / 2;
                position.X -= (Settings.WINDOW_WIDTH / 2);

                // Updating the vertical position
                position.Y = 0;
                position.Y += flufferNutter.IsDead() ? 0 : flufferNutter.CurrentPosition.Y + flufferNutter.BoundingRectangle.Height / 2;
                position.Y += cabbageLips.IsDead() ? 0 : cabbageLips.CurrentPosition.Y + cabbageLips.BoundingRectangle.Height / 2;
                position.Y = (cabbageLips.IsDead() || flufferNutter.IsDead()) ? position.Y : position.Y / 2;
                position.Y -= (Settings.WINDOW_HEIGHT / 4);
            } else {
                UpdateReferenceToPlayerCharacters();
            }


            // Makes sure the camera does not move further down than the starting position
            if (position.Y > 0)
            {
                position.Y = 0;
            }

            /*
             * Updating the list of active actors (i.e actor objects positioned inside the camera view)
             * 
             * TODO: How to improve this solution?
             */

            List<Actor> activeActors = ActorManager.getListOfActiveActors();
            activeActors.Clear();

            foreach (Actor actor in ActorManager.getListOfAllActors())
            {
                // Deactivates all active actors which is not CabbageLips or FlufferNutter
                if (actor.active && !(actor is CabbageLips || actor is FlufferNutter))
                {
                    actor.Deactivate();
                }
                // Kills all characters below the screen
                if (actor is Character && actor.BoundingRectangle.Y >= (Settings.WINDOW_HEIGHT + 500))
                {
                    ((Character)actor).Kill();
                }
                // Activate actors that is placed within the screen
                if ((
                    (actor.CurrentPosition.X > (position.X)) &&
                    (actor.CurrentPosition.X < (position.X + size.X))
                    ) || (
                    ((actor.CurrentPosition.X + actor.BoundingRectangle.Width) > (position.X)) &&
                    ((actor.CurrentPosition.X + actor.BoundingRectangle.Width) < (position.X + size.X))
                    ))
                {
                    activeActors.Add(actor);
                    actor.Activate();
                }
            }
                
        }

        public void DrawDebug(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/MenuInfoFont"), "Camera: (" + position.X + ", " + (int)position.Y + ") ", new Vector2(500, 10), Color.White);
            spriteBatch.DrawString(GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/MenuInfoFont"), "Testing: (" + (position.X - 500) + ", " + (position.X + size.X + 500) + ") ", new Vector2(500, 40), Color.White);
            spriteBatch.DrawString(GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/MenuInfoFont"), "Fluffer: (" + flufferNutter.CurrentPosition.X + ", " + (int)flufferNutter.CurrentPosition.Y + ") : " + flufferNutter.active + " : " + flufferNutter.HealthPoints , new Vector2(500, 70), Color.White);
            spriteBatch.DrawString(GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/MenuInfoFont"), "Cabbage: (" + cabbageLips.CurrentPosition.X + ", " + (int)cabbageLips.CurrentPosition.Y + ") : " + cabbageLips.active + " : " + cabbageLips.HealthPoints , new Vector2(500, 100), Color.White);
        }
    }
}