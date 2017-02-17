using System;

namespace SuperCoolRpg
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (RpgGame game = new RpgGame())
            {
                game.Run();
            }
        }
    }
#endif
}

