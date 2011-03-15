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
    class Camera
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

            UpdatePlayerCharacters();
        }

        private void UpdatePlayerCharacters()
        {
            this.flufferNutter = ActorManager.GetFlufferNutterInstance();
            this.cabbageLips = ActorManager.GetCabbageLipsInstance();
        }

        public void Move(Direction direction)
        {
            //position.X += (int)direction * CameraSpeed;
        }

        public void Reset()
        {
            position = Vector2.Zero;
            //TODO: What is size?
            size = new Vector2(Settings.WINDOW_WIDTH, Settings.WINDOW_HEIGHT);
        }

        public void Update(GameTime gameTime)
        {
            if (flufferNutter != null || cabbageLips != null)
            {
                position.X = (flufferNutter.Position.X + cabbageLips.Position.X) / 2 - (Settings.WINDOW_WIDTH / 2);
            } else {
                UpdatePlayerCharacters();
            }
        }

        public void DrawDebug(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(LeagueOfLeprechauns.arial, "Camera: (" + position.X + ", " + position.Y + ")", new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(LeagueOfLeprechauns.arial, "Fluffer: (" + flufferNutter.Position.X + ", " + flufferNutter.Position.Y + ")", new Vector2(10, 40), Color.White);
            spriteBatch.DrawString(LeagueOfLeprechauns.arial, "Cabbage: (" + cabbageLips.Position.X + ", " + cabbageLips.Position.Y + ")", new Vector2(10, 70), Color.White);
        }
    }
}
