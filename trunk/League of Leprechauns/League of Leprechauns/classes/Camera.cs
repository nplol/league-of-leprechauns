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

        public int CameraSpeed
        {
            get { return cameraSpeed; }
            set { cameraSpeed = value; } 
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public Camera()
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
            //TODO: What is size?
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
                position.Y -= (Settings.WINDOW_HEIGHT / 2);

                //position.X = (flufferNutter.CurrentPosition.X + cabbageLips.CurrentPosition.X) / 2 - (Settings.WINDOW_WIDTH / 2);
                //position.Y = (flufferNutter.CurrentPosition.Y + flufferNutter.BoundingRectangle.Height/2 + cabbageLips.CurrentPosition.Y + cabbageLips.BoundingRectangle.Height/2) / 2 - (Settings.WINDOW_HEIGHT / 2); // TODO: posisjonen til spillerne er øverst til venstre, den nederste vil derfor forsvinne først
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

            foreach (Actor actor in activeActors)
            {
                if(!(actor is CabbageLips || actor is FlufferNutter)) {
                    actor.Deactivate();
                }
            }

            activeActors.Clear();

            foreach (Actor actor in ActorManager.getListOfAllActors())
            {
                /*if (actor is CabbageLips || actor is FlufferNutter)
                {
                    if ((actor.CurrentPosition.X > position.X) && (actor.CurrentPosition.X + actor.BoundingRectangle.Width < position.X + size.X))
                    {
                        activeActors.Add(actor);
                        actor.Activate();
                    }
                    break;
                }*/

                if ((actor.CurrentPosition.X > position.X - 500) && (actor.CurrentPosition.X < position.X + size.X + 500))
                {
                    activeActors.Add(actor);
                    actor.Activate();
                }
            }
                
        }

        public void DrawDebug(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(LeagueOfLeprechauns.arial, "Camera: (" + position.X + ", " + (int)position.Y + ") ", new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(LeagueOfLeprechauns.arial, "Fluffer: (" + flufferNutter.CurrentPosition.X + ", " + (int)flufferNutter.CurrentPosition.Y + ") : " + flufferNutter.Scale.Y, new Vector2(10, 40), Color.White);
            spriteBatch.DrawString(LeagueOfLeprechauns.arial, "Cabbage: (" + cabbageLips.CurrentPosition.X + ", " + (int)cabbageLips.CurrentPosition.Y + ") : " + cabbageLips.Scale.Y, new Vector2(10, 70), Color.White);
        }
    }
}
