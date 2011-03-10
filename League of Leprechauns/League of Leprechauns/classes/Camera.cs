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
    class Camera
    {
        ActorManager actorManager;
        Vector2 position, size;

        public int CameraSpeed { get; set; }
        
        public enum CameraDirection { LEFT = -1, RIGHT = 1 }

        public Camera(ActorManager actorManager)
        {
            this.actorManager = actorManager;

            position = new Vector2(0, 0);
            size = new Vector2(800,600); // Kun en eksempeloppløsning
        }

        public void moveCamera(CameraDirection direction)
        {

        }
    
    }
}
