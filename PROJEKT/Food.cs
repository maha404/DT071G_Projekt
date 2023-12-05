using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    internal class Food
    {
        // Properties
        public string snakeFood;
        public int foodX;
        public int foodY;

        // Constructor
        public Food()
        {
            snakeFood = "#";
            DrawNewFood(); // Kallar på metoden DrawNewFood för att hämta ett nytt värde/placering för maten
        }

        // Methods

        // Ritar ut maten på spelplanen
        public void DrawFood()
        {
            Console.SetCursorPosition(foodX, foodY);
            Console.Write(snakeFood);
            
        }


        // Ritar om maten på en ny plats på spelplanen
        public void DrawNewFood()
        {
            Random random = new Random();
            foodX = random.Next(0, Console.WindowWidth);
            foodY = random.Next(0, Console.WindowHeight);
        }

        

    }
}
