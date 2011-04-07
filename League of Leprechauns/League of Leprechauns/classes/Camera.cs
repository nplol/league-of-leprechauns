using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{

    public enum Direction { LEFT = -1, UP = -1, RIGHT = 1, DOWN = 1 }
    public class Camera
    {
        private Vector2 position, size;
        private FlufferNutter flufferNutter;
        private CabbageLips cabbageLips;

        private static Camera instance;

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

            UpdateReferenceToPlayerCharacters();
        }

        /// <summary>
        /// Updates the references to FlufferNutter and CabbageLips
        /// </summary>
        private void UpdateReferenceToPlayerCharacters()
        {
            this.flufferNutter = ActorManager.GetFlufferNutterInstance;
            this.cabbageLips = ActorManager.GetCabbageLipsInstance;
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
        public void Update(GameTime gameTime, bool keepAllActorsActive)
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

            if (position.Y > cabbageLips.CurrentPosition.Y - 100)
                position.Y = cabbageLips.CurrentPosition.Y - 100;
            else if (position.Y > flufferNutter.CurrentPosition.Y - 100)
                position.Y = flufferNutter.CurrentPosition.Y - 100;

            List<Actor> activeActors = ActorManager.GetListOfActiveActors();
            activeActors.Clear();

             // Updating the list of active actors (i.e actor objects positioned inside the camera view)
            if (keepAllActorsActive)
            {
                if (ActorManager.GetListOfAllActors().Count != ActorManager.GetListOfActiveActors().Count)
                {
                    foreach (Actor actor in ActorManager.GetListOfAllActors())
                    {
                        if (!actor.Active)
                            actor.Activate();
                        if (!ActorManager.GetListOfActiveActors().Contains(actor))
                            ActorManager.GetListOfActiveActors().Add(actor);
                    }
                }
            } else {
                foreach (Actor actor in ActorManager.GetListOfAllActors())
                {
                    // Deactivates all active actors which is not CabbageLips or FlufferNutter
                    if (actor.Active && !(actor is IKeepActive))
                    {
                        actor.Deactivate();
                    }
                    // Kills all characters below the screen
                    if (actor is Character && actor.BoundingRectangle.Y >= (Settings.WINDOW_HEIGHT + Settings.MAXIMUM_LEVEL_DEPTH) && !((Character)actor).IsDead())
                    {
                        ((Character)actor).Kill(false);
                    }
                    // Activate actors that are placed within the screen
                    if (actor.Active ||
                        (
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
        }
    }
}