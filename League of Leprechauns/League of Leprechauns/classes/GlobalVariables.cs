using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class GlobalVariables
    {
        private static ContentManager contentManager;
        private static GraphicsDevice graphicsDevice;

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
