﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class GlobalVariables
    {
        private static ContentManager contentManager;
        private static GraphicsDevice graphicsDevice;
        private static ActorFactory actorFactory;

        public static ActorFactory ActorFactory
        {
            get { return actorFactory; }
            set { actorFactory = value; }
        }

        public static ContentManager ContentManager
        {
            get { return contentManager; }
            set { contentManager = value; }
        }

        public static GraphicsDevice GraphicsDevice
        {
            get { return graphicsDevice; }
            set { graphicsDevice = value; }
        }
    }
}
