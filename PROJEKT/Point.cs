using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace PROJEKT
{
    public class Point
    {
        // Properties
        public int Points { get; set; }
        public int Highscore { get; set; }

        public string path = @"highscore.json";

        // Constructor
        public Point()
        {
            Points = 0;
            Highscore = 0;
        }

        // Method
        public void PrintPoints()
        {
            Console.SetCursorPosition(0,0);
            Console.Write($"Poäng: {Points}");
        }

        public int AddPoint()
        {
           return Points++;
        }

    }
}
