// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
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
using System.Xml.Linq;
using System.Xml.Serialization;
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
        Score score = new Score();

        public bool hasCollision = false;

        //Methods

        // Method för att starta spelet. 
        public void StartGame()
        {

            Console.Clear();

            bool GameOver = false;
            bool levelChanged = false;
            
            // Loop som loopar medans GameOver är false.
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
                if (point.Points >= 13 && point.Points <= 23 && !levelChanged)
                {
                    ChangeLevel(1);
                    speed.ResetSpeed();
                    levelChanged = true;  
                }
                
                // If villkor som kollar om en kollision har skett. 
                if (HasCollision())
                {
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.WriteLine("");
                    Console.WriteLine($"Poäng: {point.Points}");
                    SaveHighscore(point.Points);

                    List<Score> highscores = GetHighscore();
                    foreach(var highscore in highscores)
                    {
                        Console.WriteLine($"Nuvarande highscore: {highscore.Highscore}");
                    }

                    Console.WriteLine("Tryck på en tangent för att gå tillbaka till startmenyn");
                    Console.ReadLine();
                    Program.Main();
                }
            }
        }
        // Method som kör en level. 
        public void RunLevel(int levelNumber)
        {
            bool GameOver = false;
            // Sätter ormen mitt i de olika nivåerna så den inte krockar in i väggen när en ny nivå påbörjas
            snake.ResetPosition(levelNumber == 1 ? level1.Width / 2 : level2.Width / 2, levelNumber == 1 ? level1.Height / 2: level2.Height / 2);
            // Återställer farten på ormen
            speed.ResetSpeed();

            while (!GameOver)
            {
                Console.Clear();
                Render(levelNumber == 1 ? level1.Width : level2.Width, levelNumber == 1 ? level1.Height : level2.Height);   
                inputHandler.HandleInput();
                Collision(levelNumber == 1 ? level1.Width : level2.Width, levelNumber == 1 ? level1.Height : level2.Height);
                Thread.Sleep(speed.ReturnSpeed());

                // If villkor som kollar poäng och byter nivå. 
                if (point.Points > 23 && levelNumber == 1)
                {
                    ChangeLevel(2);
                }

                // If villkor som kollar om en kollision har skett. 
                if (HasCollision())
                {
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.WriteLine("");
                    Console.WriteLine($"Poäng: {point.Points}");
                    SaveHighscore(point.Points);

                    List<Score> highscores = GetHighscore();
                    foreach (var highscore in highscores)
                    {
                        Console.WriteLine($"Nuvarande highscore: {highscore.Highscore}");
                    }

                    Console.WriteLine($"Level: {levelNumber}");
                    Console.WriteLine("Tryck på en tangent för att gå tillbaka till startmenyn");
                    Console.ReadLine();
                    Program.Main();
                }

                
            }
        }
        // Method som ändrar level. 
        public void ChangeLevel(int levelNumber)
        {
            Console.Clear();
            Console.WriteLine($"Level {levelNumber}");
            Console.WriteLine("Klicka på '1' för att starta nästa level!");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    food.DrawNewFood(levelNumber == 1 ? level1.Width : level2.Width, levelNumber == 1 ? level1.Height : level2.Height);
                    RunLevel(levelNumber);
                    break;

            }

        }
        // Method som kollar kollision. 
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
        // Method som kollar om en kollision har hänt eller ej. 
        public bool HasCollision()
        {
            return hasCollision;
        }
        // Method som skriver ut alla delar av spelet till konsolen. 
        public void Render(int width, int height)
        {
            Console.Clear();
            gameBoard.DrawBorder(width, height);
            snake.DrawSnake();
            food.DrawFood();
            point.PrintPoints();
        }
        // Method som hämtar highscore från filen highscore.json.
        public static List<Score> GetHighscore()
        {
            string path = @"..\..\..\highscore.json";
    
            string json = File.ReadAllText(path);
            List<Score> highscores = JsonSerializer.Deserialize<List<Score>>(json);
            return highscores ?? new List<Score>();
                
        }
        // Method som sparar highscore till filen highscore.json. 
        public void SaveHighscore(int points)
        {
            List<Score> highscores = GetHighscore();

            string currentDirectory = Environment.CurrentDirectory;

            // Relativ sökväg till filen
            string path = Path.GetFullPath("C:\\Users\\Maria\\OneDrive\\Skrivbord\\c#\\PROJEKT\\highscore.json");

            var newHighscore = new Score
            {
                Highscore = points
            };

            if(highscores.Count == 0 || points > highscores[0].Highscore)
            {
                highscores.Clear();
                highscores.Add(newHighscore);

                string jsonString = JsonSerializer.Serialize(highscores, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, jsonString); // Spara till fil!

                Console.WriteLine("Nytt Highscore!");

            } else
            {
                Console.WriteLine("Du slog tyvärr inte ditt highscore!");
            }
       
        }

    }
}
