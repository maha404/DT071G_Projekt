using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using static PROJEKT.Level;

namespace PROJEKT
{
    class Program
    {
        
        public static void Main()
        {
           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Välkommen till Snake!");
            Console.WriteLine("Klicka på Enter för att börja");
            Console.ResetColor();

            ConsoleKeyInfo key = Console.ReadKey();
            Game game = new Game();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    game.StartGame();
                    break;

            }

              
        }

    }

}
