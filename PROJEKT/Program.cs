namespace PROJEKT
{
    class Program
    {
        public static void Main()
        {
            Point point = new Point();
            point.PrintPoints();

            switch (Console.ReadLine())
            {
                case "s":
                    Snake snake = new Snake();
                    snake.Move();
                    break;
                case "X":
                    return;

            }
            
           
           
        }

    }
}
