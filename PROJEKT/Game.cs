using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static PROJEKT.Level;

namespace PROJEKT
{
    public class Game
    {
        // Instanser av klasser
        Snake snake = new Snake();
        Point point = new Point();
        Food food = new Food();
        Position position = new Position();
        GameBoard gameBoard = new GameBoard();
        InputHandler inputHandler = new InputHandler(25, 25); // Tar in width och height för spelplanen
        Speed speed = new Speed(300); // Start fart för ormen
        Level level = new Level();
        Level1 level1 = new Level1();
        Level2 level2 = new Level2();
        public bool hasCollision = false;

        public void StartGame()
        {

            Console.Clear();

            bool GameOver = false;
            bool levelChanged = false;
            
            // Loop som loopar medans if villkoret = true
            while (!GameOver)
            {
                Console.CursorVisible = false;

                if(!levelChanged)
                {
                    Render(25, 25);
                    inputHandler.HandleInput();
                    Collision(25, 25);
                    Thread.Sleep(speed.ReturnSpeed());
                }

                // If villkor som kollar antal poäng och byter nivå
                if (point.Points >= 5 && point.Points <= 5 && !levelChanged)
                {
                    ChangeLevel(1);
                    levelChanged = true;
                }
                
                //if (point.Points >= 10 && point.Points <= 10 && !levelChanged)
                //{
                //    ChangeLevel(2);
                //    levelChanged = true;
                //}

                if (HasCollision())
                {
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.WriteLine($"Poäng: {point.Points}");
                    Program.Main();
                }


            }
        }

        public void ChangeLevel(int levelNumber)
        {
            Console.Clear();
            Console.WriteLine($"Level {levelNumber}");
            Console.WriteLine("Klicka på 'S' för att starta nästa level!");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.S:
                    RunLevel(levelNumber);
                    break;

            }

        }

        public void RunLevel(int levelNumber)
        {
            bool GameOver = false;

            // Sätter ormen mitt i de olika nivåerna så den inte krokar in i väggen när en ny nivå påbörjas
            snake.ResetPosition(levelNumber == 1 ? level1.Width / 2 : level2.Width / 2, levelNumber == 1 ? level1.Height / 2: level2.Height / 2);

            while (!GameOver)
            {
                Console.Clear();
                Render(levelNumber == 1 ? level1.Width : level2.Width, levelNumber == 1 ? level1.Height : level2.Height);   
                inputHandler.HandleInput();
                Collision(levelNumber == 1 ? level1.Width : level2.Width, levelNumber == 1 ? level1.Height : level2.Height);
                Thread.Sleep(speed.ReturnSpeed());
                // Går tillbaka till första spelloopen när nivån är klar?
                if (point.Points > 9 && levelNumber == 1)
                {
                    ChangeLevel(2);
                }

                if (HasCollision())
                {
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.WriteLine($"Poäng: {point.Points}");
                    Console.WriteLine($"Level: {levelNumber}");
                    Program.Main();
                }

                
            }
        }

        public void Collision(int width, int height)
        {
            Position head = snake.SnakeBody.First();
            // Skapar en ny instans av Position klassen och skickar iväg värden för X och Y
            Position newHead = new Position { X = head.X + inputHandler.DirectionX, Y = head.Y + inputHandler.DirectionY }; // Positionen för "huvudet"

            CollisionHandler collision = new CollisionHandler();
            if (hasCollision)
            {
                return;
            }

            if (collision.CheckWallCollision(newHead, width, height))
            {
                hasCollision = true;
                return;
            }

            snake.SnakeBody.Insert(0, newHead);

            // Kollar om huvudet på ormen och maten har kolliderat, dvs om ormen "ätit" maten
            if (newHead.X == food.foodX && newHead.Y == food.foodY)
            {
                food.DrawNewFood(width, height); // Skriver ut mat på ny plats
                point.AddPoint();  // Lägger till ett poäng 
                speed.IncreaseSpeed(20);  // Ökar hastigheten på ormen

            }
            else
            {
                // Om ormen inte har kolliderat med maten så bibehåller ormen sin längd
                snake.SnakeBody.RemoveAt(snake.SnakeBody.Count - 1);
            }

        }

        public bool HasCollision()
        {
            return hasCollision;
        }

        public void Render(int width, int height)
        {
            Console.Clear();
            gameBoard.DrawBorder(width, height);
            snake.DrawSnake();
            food.DrawFood();
            point.PrintPoints();
        }

    }
}
