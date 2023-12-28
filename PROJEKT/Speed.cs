// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    public class Speed
    {
        // Properties
        public int speed;

        // Constructor
        public Speed(int startSpeed)
        {
            speed = startSpeed;
        }

        // Methods

        // Method som ökar hastigheten
        public void IncreaseSpeed(int MoreSpeed)
        {
           if(speed != 50)
            {
               speed -= MoreSpeed;
            }
          
        } 

        // Method som returnerar hastigheten. 
        public int ReturnSpeed()
        {
            return speed;
        }

        // Method som återställer hastigheten. 
        public void ResetSpeed()
        {
            speed = 300;
        }

    }
}
