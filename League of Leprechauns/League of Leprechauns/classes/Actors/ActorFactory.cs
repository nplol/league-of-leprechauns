using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    /*
     * This class is used as a Factor for creating actors from strings
     * Primarily used by the LevelManager.
     */
    class ActorFactory
    {
        public static Actor CreateActor(string actorClassName, Vector2 position, ContentManager contentManager)
        {
            switch (actorClassName)
            {
                case "StaticPlatform":
                    //return new StaticPlatform();
                    break;
                case "MovingPlatform":
                    //return new MovingPlatform();
                    break;
                case "FlufferNutter":
                    FlufferNutter flufferNutter = new FlufferNutter(position);
                    flufferNutter.LoadContent(contentManager, @"Sprites/flufferNutterProto");
                    return flufferNutter;

                case "CabbageLips":
                    CabbageLips cabbageLips = new CabbageLips(position);
                    cabbageLips.LoadContent(contentManager, @"Sprites/cabbageLipsProto");
                    return cabbageLips;
            }
            return null;
        }
    }
}
