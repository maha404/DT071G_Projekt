// Kod skriven av Maria Halvarsson - Projekt i kursen DT071G
using System.Collections.Generic;
using System.Globalization;
using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using static PROJEKT.Level;
using Spectre.Console;
using System.Security.Cryptography;

namespace PROJEKT
{
    class Program
    {
        // Main Method
        public static void Main()
        {
            Console.Clear();
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "ASCII Art";
            string title = @"
             ________  ________   ________  ___  __    _______      
            |\   ____\|\   ___  \|\   __  \|\  \|\  \ |\  ___ \     
            \ \  \___|\ \  \\ \  \ \  \|\  \ \  \/  /|\ \   __/|    
             \ \_____  \ \  \\ \  \ \   __  \ \   ___  \ \  \_|/__  
              \|____|\  \ \  \\ \  \ \  \ \  \ \  \\ \  \ \  \_|\ \ 
                ____\_\  \ \__\\ \__\ \__\ \__\ \__\\ \__\ \_______\
               |\_________\|__| \|__|\|__|\|__|\|__| \|__|\|_______|
               \|_________|                                         
                                                 ";

            Console.WriteLine(title);
            Console.WriteLine("Tryck enter för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
            Game game = new Game();

            // En panel som kommer ifrån Spectre.Console
            var panel = new Panel("[springgreen3_1]1. Starta Spel[/] \n[yellow]2. Se highscore[/]\n[teal]3. Så spelar du[/]\n[red1]4. Avsluta[/]");
            panel.Header = new PanelHeader("Snake - Meny"); 
            panel.Border = BoxBorder.Double;
            panel.Padding = new Padding(2, 2, 2, 2);
            AnsiConsole.Write(panel);

            Console.WriteLine("");
            Console.Write("Vad vill du göra?: ");
            string choice = Console.ReadLine();
            MainMenu();

            // Method för huvudmenyn för spelet. 
            void MainMenu()
            {
                switch (choice)
                {
                    case "1":
                        game.StartGame(); // Startar spelet. 
                        break;
                    case "2":
                        Console.Clear();
                        PrintHighscore(); // Skriver ut Highscore till konsolen. 
                        break;
                    case "3":
                        HowToPlay();
                        break;
                    case "4":
                        System.Environment.Exit(0); // Avslutar programmet. 
                        break;

                }
            }

            // Method som skriver ut highscore till konsolen. 
            void PrintHighscore()
            {
                // En panel som kommer ifrån Spectre.Console
                var panel = new Panel("[springgreen3_1]1. Tillbaka till menyn[/] \n[red1]2. Rensa highscore[/]");
                panel.Header = new PanelHeader("Snake - Meny");
                panel.Border = BoxBorder.Double;
                panel.Padding = new Padding(2, 2, 2, 2);
                AnsiConsole.Write(panel);

                List<Score> highscores = Game.GetHighscore();
                foreach (var highscore in highscores)
                {
                    Console.WriteLine($"Nuvarande highscore: {highscore.Highscore}");
                }

                Console.WriteLine("");
                Console.Write("Vad vill du göra?: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Main();
                        break;
                    case "2":
                        Console.Clear();
                        DeleteHighscore();
                        break;
                }

                // Method som rensar highscore listan. 
                void DeleteHighscore()
                {
                    string path = @"..\..\..\highscore.json";
                    string empty = "[]";
                    File.WriteAllText(path, empty);

                    Console.WriteLine("Highscore rensades!");
                    PrintHighscore();
                }

            }
            
            void HowToPlay()
            {
                Console.Clear();
                var panel = new Panel("Använd piltangenterna för att styra ormen.\nOm du krockar in i någon utav de fyra väggarna så kommer spelet att avslutas");
                panel.Header = new PanelHeader("Snake - Så spelar du");
                panel.Border = BoxBorder.Double;
                panel.Padding = new Padding(2, 2, 2, 2);
                AnsiConsole.Write(panel);
                Console.WriteLine("Klicka på enter för att komma tillbaka till huvudmenyn");
                Console.ReadKey();
                Main();
            }
        }
    }

}
