using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace League_of_Leprechauns
{
    class Actor
    {
        static List<Actor> Actors;
        private Texture2D texture;
        private Vector2 position;

        static Actor()
        {
            Actors = new List<Actor>();
        }

        public Actor()
        {
            Actors.Add(this);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}