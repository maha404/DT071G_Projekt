// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PROJEKT
{
    public class Snake
    {
        // Properties
        public List<Position> SnakeBody;
        public int snakeLenght;
        
        // Constructor
        public Snake()
        {
            SnakeBody = new List<Position>();
            SnakeBody.Add(new Position { X = 5, Y = 5 });
            snakeLenght = 1;
        }

        // Ritar ut ormen på konsolen
        public void DrawSnake()
        {
         
            foreach (Position part in SnakeBody)
            {
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write("■");
            }
           
        }

        // Återställer positionen och längden på ormen så den inte skrivs ut i en av ramarna. 
        public void ResetPosition(int centerX, int CenterY)
        {
            SnakeBody.Clear();
            SnakeBody.Add(new Position { X = centerX, Y = CenterY });
            snakeLenght = 1;
        }

    }
}
