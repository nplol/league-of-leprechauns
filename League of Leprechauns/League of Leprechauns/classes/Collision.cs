using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL
{
    public enum CollisionType
    {
        COLLIDE_LEFT,
        COLLIDE_RIGHT,
        COLLIDE_UP,
        COLLIDE_DOWN
    }

    public struct Collision
    {
        public CollisionType CollisionType;


    }
}
