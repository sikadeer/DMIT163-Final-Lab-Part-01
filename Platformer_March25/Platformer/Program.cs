using System;

namespace Platformer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Platformer game = new Platformer())
            {
                game.Run();
            }
        }
    }
}

