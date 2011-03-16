﻿using System;
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
        public Actor createActor(string actorClassName, Vector2 position, ContentManager contentManager)
        {
            switch (actorClassName)
            {
                case "StaticPlatform":
                    StaticPlatform staticPlatform = new StaticPlatform(position);
                    staticPlatform.LoadContent(contentManager, @"Sprites/Ground/groundSpriteWoods");
                    return staticPlatform;

                case "MovingPlatform":
                    //return new MovingPlatform();
                    break;
                case "FlufferNutter":
                    FlufferNutter flufferNutter = new FlufferNutter(position, 1, 100, Vector2.Zero, 0);
                    flufferNutter.LoadContent(contentManager, @"Sprites/Characters/fluffernutterProto");
                    return flufferNutter;

                case "CabbageLips":
                    CabbageLips cabbageLips = new CabbageLips(position, 1, 100, Vector2.Zero, 0);
                    cabbageLips.LoadContent(contentManager, @"Sprites/Characters/cabbagelipsProto");
                    return cabbageLips;
            }
            return null;
        }
    }
}