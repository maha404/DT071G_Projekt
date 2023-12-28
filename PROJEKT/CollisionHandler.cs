// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    
    public class CollisionHandler
    {
        // Methods

        // Method som returnerar en bool (true eller false) beroende på om ormen har krockat in i någon av väggarna. 
        public bool CheckWallCollision(Position newhead, int boardWidth, int boardHeight)
        {
            bool isCollision = newhead.X < 1 || newhead.X >= boardWidth - 1 || newhead.Y < 1 || newhead.Y >= boardHeight - 1;
            return isCollision;
        }

    }
    
}
