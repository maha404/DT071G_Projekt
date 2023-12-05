using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT
{
    public class Snake
    {
        // Properties
        public List<Position> SnakeBody;
        public int snakeLenght;
        public int DirectionX;
        public int DirectionY;
        public int sides;
        public int top;
        public int Speed;
      
        // Constructor
        public Snake()
        {
            //snakeBody = "■";
            SnakeBody = new List<Position>();
            SnakeBody.Add(new Position { X = 10, Y = 10 });
            Speed = 200;
            snakeLenght = 1;
            DirectionX = 1;
            DirectionY = 0;
            sides = 20;
            top = 20;
        }
        Food food = new Food();
        Point point = new Point();


        // Methods
        public void Move()
        {
            
            // Loop som loopar medans if villkoret = true,
            // if villkoret kollar om en tangent finns tillgänglig i input stream. 
            while (true)
            {
                Console.CursorVisible = false;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            DirectionX = 1;
                            DirectionY = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            DirectionX = -1;
                            DirectionY = 0;
                            break;
                        case ConsoleKey.UpArrow:
                            DirectionX = 0;
                            DirectionY = -1;
                            break;
                        case ConsoleKey.DownArrow:
                            DirectionX = 0;
                            DirectionY = 1;
                            break;
                    }
                }

                sides += DirectionX;
                top += DirectionY;

                if (Console.WindowHeight > Console.WindowWidth)
                {
                    // Anpassa hastigheten baserat på höjden av konsolfönstret
                    Speed = (int)(Speed * (Console.WindowWidth / (double)Console.WindowHeight));
                }

                MoveSnake();
                DrawSnake();
                
                point.PrintPoints(); // Skriver ut poäng till konsolen

                Thread.Sleep(Speed);// Speed på ormen
                
            }

        }

        // Metod som flyttar ormen och kollar om maten har ätits eller ej
       public void MoveSnake()
       {
            Position head = SnakeBody.First();
            // Skapar en ny instans av Position klassen och skickar iväg värden för X och Y
            Position newHead = new Position { X = head.X + DirectionX, Y = head.Y + DirectionY };

            // Lägger till en längd till ormen. 
            SnakeBody.Insert(0, newHead);

            // Kollar om huvudet på ormen och maten har kolliderat, dvs om ormen "ätit" maten
            if(newHead.X == food.foodX && newHead.Y == food.foodY)
            {
                // Skrivet ut mat på ny plats
                food.DrawNewFood();

                // Ökar hastigheten på ormen
                IncreaseSpeed();

                // Lägger till ett poäng 
                point.point++;
           
            } else
            {
                // Om ormen inte har kolliderat med maten så bibehåller ormen sin längd
                SnakeBody.RemoveAt(SnakeBody.Count - 1);
            }
       }

        // Ökar hastigheten på ormen
        public void IncreaseSpeed()
        {
            if( Speed > 50)
            {
                Speed -= 20;
            }
        }

        // Ritar ut ormen på konsolen
        public void DrawSnake()
        {
            Console.Clear();
            foreach(Position part in SnakeBody)
            {
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write("■");
            }

             food.DrawFood();
        
        }

    }
}
