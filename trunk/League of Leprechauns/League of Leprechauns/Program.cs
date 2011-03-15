using System;

namespace LoL
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (LeagueOfLeprechauns game = new LeagueOfLeprechauns())
            {
                game.Run();
            }
        }
    }
#endif
}

