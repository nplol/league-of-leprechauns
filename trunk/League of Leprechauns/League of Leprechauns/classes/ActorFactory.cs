using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    /*
     * This class is used as a Factory for creating actors from strings
     * Primarily used by the LevelManager.
     */
    class ActorFactory
    {
        /// <summary>
        /// Method to create actor instances
        /// </summary>
        /// <param name="actorClassName">The textual name of the actor class</param>
        /// <param name="position">The start position of the actor</param>
        /// <param name="contentManager">Reference to the contentManager for loading textures</param>
        /// <returns>An actor instance</returns>
        public Actor createActor(string actorClassName, Vector2 position, ContentManager contentManager)
        {
            switch (actorClassName)
            {
                case "StaticPlatform":
                    StaticPlatform staticPlatform = new StaticPlatform(position);
                    staticPlatform.LoadContent(contentManager, @"Sprites/Ground/groundSpriteWoods");
                    return staticPlatform;
                case "NonLivingObject":
                    NonLivingObject nonLivingObject = new NonLivingObject(position);
                    nonLivingObject.LoadContent(contentManager, @"Sprites/Ground/groundSpriteWoodsUnder");
                    return nonLivingObject;
                case "MovingPlatform":
                    //return new MovingPlatform();
                    break;
                case "FlufferNutter":
                    FlufferNutter flufferNutter = new FlufferNutter(position, 1, 100, Vector2.Zero, Settings.DEFAULT_JUMPFORCE);
                    flufferNutter.LoadContent(contentManager, @"Sprites/Characters/fluffernutter-proto-sprite");
                    return flufferNutter;

                case "CabbageLips":
                    CabbageLips cabbageLips = new CabbageLips(position, 1, 100, Vector2.Zero, Settings.DEFAULT_JUMPFORCE);
                    cabbageLips.LoadContent(contentManager, @"Sprites/Characters/cabbagelips-sprite");
                    return cabbageLips;
                case "BackgroundObject":
                    //Textures bør taes inn i levelfilen.
                    return null;

            }
            return null;
        }
    }
}
