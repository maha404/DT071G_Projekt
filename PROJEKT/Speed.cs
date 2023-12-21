using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    public class Speed
    {
        public int speed;

        public Speed(int startSpeed)
        {
            speed = startSpeed;
        }

        public void IncreaseSpeed(int MoreSpeed)
        {
           if(speed != 50)
            {
               speed -= MoreSpeed;
            }
          
        } 

        public int ReturnSpeed()
        {
            return speed;
        }

    }
}
