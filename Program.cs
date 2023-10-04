using System;
using System.Threading;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string input = Console.ReadLine().ToLower();

            if (input == "0")
            {
                Environment.Exit(0);
            }

            int timeInSeconds = ParseTime(input);

            if (timeInSeconds > 0)
            {
                Start(timeInSeconds);
            }
            else
            {
                Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar.");
                Console.ReadKey();
                Menu();
            }
        }

        static int ParseTime(string input)
        {
            char type = input[^1];

            if (type == 's' || type == 'm')
            {
                int multiplier = (type == 'm') ? 60 : 1;
                input = input.Substring(0, input.Length - 1);

                if (int.TryParse(input, out int time))
                {
                    return time * multiplier;
                }
            }
            return -1;
        }

        static void Start(int timeInSeconds)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            var endTime = DateTime.Now.AddSeconds(timeInSeconds);

            while (DateTime.Now < endTime)
            {
                Console.Clear();
                TimeSpan remainingTime = endTime - DateTime.Now;
                Console.WriteLine(remainingTime.ToString(@"mm\:ss"));
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("StopWatch finalizado");
            Thread.Sleep(2500);
            Menu();
        }

    }
}
