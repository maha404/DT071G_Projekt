using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    public class Level
    {
        public int width = 20;
        public int height = 10;
        public int sides = 10;
        public int top = 10;

        public void drawLevel()
        {
            // Rita den övre linjen
            Console.Write("+");
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");

            // Rita sidorna
            for(int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("|");
            }

            // Rida den nedre linjen + hörn
        }

        
    }
}
