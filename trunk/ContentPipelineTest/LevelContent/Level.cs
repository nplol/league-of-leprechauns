using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LevelContent
{
    public class Level
    {
        Vector2 position;
        float rotation;
        Vector2 scale;

        string textureAsset;
        Texture2D texture;

        public Vector2 Position
        {
            get;
            set;
        }

        public float Rotation
        {
            get;
            set;
        }

        public Vector2 Scale
        {
            get;
            set;
        }

        public string TextureAsset
        {
            get;
            set;
        }

        public Vector2 TextureAsset
        {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public Texture2D Texture
        {
            get;
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>(@textureAsset);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
