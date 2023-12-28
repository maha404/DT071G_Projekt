// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    public class GameBoard
    {
        // Methods 

        // Method som ritar ut en ram för spelplanen beroende på höjd och bredd. 
        public void DrawBorder(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
                Console.SetCursorPosition(i, height - 1);
                Console.Write("-");
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(width - 1, i);
                Console.Write("|");
            }
        }

    }
    
}

