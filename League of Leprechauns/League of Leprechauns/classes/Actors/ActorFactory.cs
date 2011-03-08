using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL
{
    /*
     * This class is used as a Factor for creating actors from strings
     * Primarily used by the LevelManager.
     */
    class ActorFactory
    {
        public static Actor CreateActor(string actorClassName)
        {
            switch (actorClassName)
            {
                case "StaticPlatform":
                    //return new StaticPlatform();
                    break;
                case "MovingPlatform":
                    //return new MovingPlatform();
                    break;
            }
            return null;
        }
    }
}
