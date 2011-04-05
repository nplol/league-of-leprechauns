using Microsoft.Xna.Framework;

namespace LoL
{
    class TutorialObject : BackgroundObject
    {
        /// <summary>
        /// Instanciates a new TutorialObject.
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="tutorialText">The text displayed on screen as part of the tutorial.</param>
        /// <param name="fixedPosition"></param>
        public TutorialObject(Vector2 startPosition, bool fixedPosition)
            : base(startPosition, fixedPosition)
        {
        }

    }
}
