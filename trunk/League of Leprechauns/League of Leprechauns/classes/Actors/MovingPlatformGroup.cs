using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class which represents a group of moving platforms, 
    /// making their interactions easier.
    /// </summary>
    class MovingPlatformGroup : Actor, IKeepActive
    {
        #region attributes
        private List<MovingPlatform> platforms;
        #endregion

        #region Properties
        public override Rectangle PotentialMoveRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
        }
        #endregion

        /// <summary>
        /// Instanciates a new MovingPlatformGroup.
        /// </summary>
        /// <param name="startPosition"></param>
        public MovingPlatformGroup(Vector2 startPosition)
            : base(startPosition)
        {
            platforms = new List<MovingPlatform>();
        }

        /// <summary>
        /// Initialises the moving platform group,
        /// adding all existing moving platforms.
        /// </summary>
        public void Initialize()
        {
            for (int i = 0; i < ActorManager.getListOfAllActors().Count; ++i)
            {
                if (ActorManager.getListOfAllActors().ElementAt(i) is MovingPlatform)
                    AddPlatform((MovingPlatform)ActorManager.getListOfAllActors().ElementAt(i));
            }
        }

        /// <summary>
        /// Adds a new platform to the list of moving platforms.
        /// All even numbered platforms are given positive speed vectors, while
        /// odd numebered platforms are given negative speed vectors.
        /// </summary>
        /// <param name="platform">The platform to be added</param>
        public void AddPlatform(MovingPlatform platform)
        {
            /// All odd numbered platforms should have
            /// negative speed vectors.
            if (platforms.Count % 2 != 0)
                platform.Speed *= -1;

            platforms.Add(platform);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="camera"></param>
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Camera camera)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
