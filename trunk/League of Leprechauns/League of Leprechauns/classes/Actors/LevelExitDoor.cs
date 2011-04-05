using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class describing the actions of the level exit doors. These doors represent the
    /// end of the current level.
    /// </summary>
    class LevelExitDoor : Actor
    {
        /// <summary>
        /// Instanciates a new level exit door.
        /// </summary>
        /// <param name="startPosition"></param>
        public LevelExitDoor(Vector2 startPosition)
            : base(startPosition)
        {

        }
    }
}
