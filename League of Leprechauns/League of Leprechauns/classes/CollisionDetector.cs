using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    /*
     * Klasse for å oppdage potensielle kollisjoner     
     */ 
    static class CollisionDetector
    {
        public static void DetectCollisions(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                foreach (Actor actor2 in actors)
                {
                    //Først generer en liste over alle actors vi potensielt kommer til å kollidere med. 
                    //Så må vi avgjøre hvor stor kraft vi må apply'e for å unngå kollisjonen. 
                    //Potensielt problem: hvis actor beveger seg mot actor2, og actor2 beveger seg mot actor så vil begge
                    //detecte en collision, og applye en force i motsatt retning for å unngå kollisjonen.
                }
            }
        }
    }
}
