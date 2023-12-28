// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
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
            snakeFood = "#"; // Symbolen för maten. 
            DrawNewFood(5, 5); // Kallar på metoden DrawNewFood för att hämta ett nytt värde/placering för maten. 
        }

        // Methods

        // Ritar ut maten på spelplanen. 
        public void DrawFood()
        {
            Console.SetCursorPosition(foodX, foodY);
            Console.Write(snakeFood);
        }

        // Ritar om maten på en ny plats på spelplanen. 
        public void DrawNewFood(int width, int height)
        {
            Random random = new Random();
            foodX = random.Next(1, width - 1); // -1 för att maten inte ska skrivas ut i ramen.
            foodY = random.Next(1, height - 1);
        }

    }
}
