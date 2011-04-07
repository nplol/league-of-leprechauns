using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class describing the actions of the level exit doors. These doors represent the
    /// end of the current level.
    /// </summary>
    class LevelExitDoor : Actor, IIgnorable
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
