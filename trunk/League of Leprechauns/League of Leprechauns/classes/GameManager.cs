using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    class GameManager
    {
        Camera camera;
        LevelManager levelManager;

        public GameManager(ContentManager content)
        {
            levelManager = new LevelManager(content);
            levelManager.ChangeLevel(1);
        }


        public void Update(GameTime gameTime)
        {
            foreach (Actor actor in ActorManager.getListOfAllActors())
            {
                actor.Update(gameTime);
            } 
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            foreach (Actor actor in ActorManager.getListOfAllActors())
            {
                actor.Draw(spriteBatch);
            }
        }
    }
}
