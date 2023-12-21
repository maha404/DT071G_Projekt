using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    public class Level
    {
        public int LevelNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


        public class Level1 : Level
        {
            public Level1()
            {
                LevelNumber = 1;
                Width = 30;
                Height = 20;
            }

        }

        public class Level2 : Level
        {
            public Level2()
            {
                LevelNumber = 2;
                Width = 20;
                Height = 15;
            }
        }

    }
}
