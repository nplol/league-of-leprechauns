using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content;

namespace LevelEditor
{
    class GameItem
    {
        public string ActorType;
   
        [ContentSerializerIgnore]
        public Texture2D Texture;
        public Vector2 Position;

        [ContentSerializerIgnore]
        private Vector2 scale;

        [ContentSerializerIgnore]
        public int Width
        {
            get { return Texture.Width; }
        }

        [ContentSerializerIgnore]
        public int Height
        {
            get { return Texture.Height; }
        }

        [ContentSerializerIgnore]
        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public GameItem(Texture2D texture, Vector2 position)
        {
            this.ActorType = "test";
            this.Texture = texture;
            this.Position = position;
            this.scale = new Vector2(1, 1);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
        //    spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(Texture, Position - camera.Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
