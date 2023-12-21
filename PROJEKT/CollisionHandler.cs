using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    
        public class CollisionHandler
        {
           
        public bool CheckWallCollision(Position newhead, int boardWidth, int boardHeight)
        {
            bool isCollision = newhead.X < 1 || newhead.X >= boardWidth - 1 || newhead.Y < 1 || newhead.Y >= boardHeight - 1;
            return isCollision;
        }

    }
    
}
