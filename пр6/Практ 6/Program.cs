namespace Практ_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до открываемого файла");
            Console.WriteLine();
            string? path = Console.ReadLine();
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            Converter converter = new Converter();
            List<Car> cars = converter.Load(path);

            Console.Clear();
            Console.WriteLine("Сохранить - F1. Выход - Esc");
            foreach (Car car in cars)
            {
                Console.WriteLine(car.owner);
                Console.WriteLine(car.mark);
                Console.WriteLine(car.year);
            }

            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.F1)
            {
                key = Console.ReadKey(true);
            }
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            
            Console.Clear();
            Console.WriteLine("Введите путь до сохраняемого файла");
            Console.WriteLine();
            path = Console.ReadLine();
            if (String.IsNullOrEmpty(path))
            {
                return;
            }
            converter.Save(cars, path);
        }
    }
}