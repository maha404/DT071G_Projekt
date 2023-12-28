// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    public class InputHandler
    {
        // Properties
        public int DirectionX;
        public int DirectionY;
        public int Sides;
        public int Top;

        // Constructor
        public InputHandler(int top, int sides)
        {
            DirectionX = 1;
            DirectionY = 0;
            Sides = sides;
            Top = top;
        }

        // Methods 

        // Method för att hantera användarens tangent input.
        public void HandleInput()
        {
            // if villkoret kollar om en tangent finns tillgänglig i input stream. 
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        DirectionX = 1;
                        DirectionY = 0;
                        break;

                    case ConsoleKey.LeftArrow:
                        DirectionX = -1;
                        DirectionY = 0;
                        break;

                    case ConsoleKey.UpArrow:
                        DirectionX = 0;
                        DirectionY = -1;
                        break;

                    case ConsoleKey.DownArrow:
                        DirectionX = 0;
                        DirectionY = 1;
                        break;
                }

                Sides += DirectionX;
                Top += DirectionY;

            }
        }
    }
}
