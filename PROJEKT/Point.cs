// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
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
        
        // Constructor
        public Point()
        {
            Points = 0;
        }

        // Method

        // Method som skriver ut poängen till konsolen. 
        public void PrintPoints()
        {
            Console.SetCursorPosition(0,0);
            Console.Write($"Poäng: {Points}");
        }

        // Method som lägger till poäng
        public int AddPoint()
        {
            return Points++;
        }

    }
}
