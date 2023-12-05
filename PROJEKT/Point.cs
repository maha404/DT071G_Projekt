using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    public class Point
    {
        // Properties
        public int point;
        
        // Constructor
        public Point()
        {
            point = 0;
        }

        // Method
        public void PrintPoints()
        {
            Console.SetCursorPosition(0,0);
            Console.Write($"Poäng: {point}");
        }


    }
}
