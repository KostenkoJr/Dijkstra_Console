using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int SIZE = 100;
                Console.WriteLine("Для выбора какого либо пункта введите соответствующее число:");
                Console.WriteLine("1. Ввесте самостоятельно размерность матрицы");
                Console.WriteLine("2. Сформировать случайную матрицу размерности 5х5");
                Console.WriteLine("3. Сформировать случайную матрицу размерности 10х10");
                Console.WriteLine("4. Сформировать случайную матрицу размерности 20х20");
                Console.WriteLine("5. Выйти");
                Console.Write("Ваш выбор: ");
                int selection = Convert.ToInt32(Console.ReadLine());

                int[,] arr = new int[SIZE, SIZE];
                switch (selection)
                {
                    case 1:
                        Console.Write("Ввести размерность матрицы (от 2 до 100): ");
                        SIZE = Convert.ToInt32(Console.ReadLine());

                        Random rand = new Random();
                        for (int i = 0; i < SIZE; i++)
                        {
                            for (int j = 0; j < SIZE; j++)
                            {
                                arr[i, j] = arr[j, i] = rand.Next(0, 100);
                                arr[i, i] = 0;
                            }
                        }
                        break;
                    case 2:
                        SIZE = 5;

                        Random random = new Random();
                        for (int i = 0; i < SIZE; i++)
                        {
                            for (int j = 0; j < SIZE; j++)
                            {
                                arr[i, j] = arr[j, i] = random.Next(0, 100);
                                arr[i, i] = 0;
                            }
                        }
                        break;
                    case 3:
                        SIZE = 10;

                        Random rando = new Random();
                        for (int i = 0; i < SIZE; i++)
                        {
                            for (int j = 0; j < SIZE; j++)
                            {
                                arr[i, j] = arr[j, i] = rando.Next(0, 100);
                                arr[i, i] = 0;
                            }
                        }
                        break;
                    case 4:
                        SIZE = 20;

                        Random ran = new Random();
                        for (int i = 0; i < SIZE; i++)
                        {
                            for (int j = 0; j < SIZE; j++)
                            {
                                arr[i, j] = arr[j, i] = ran.Next(0, 100);
                                arr[i, i] = 0;
                            }
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Сделайте корректный выбор!");
                        break;
                }

                /** Вывод в консоль матрицы */
                Console.Write("      ");
                for (int i = 0; i < SIZE; i++)
                {
                    Console.Write("[{0,3} ] ", i);
                }

                Console.WriteLine();
                Console.Write("      ");
                for (int j = 0; j < SIZE; j++)
                {
                    Console.Write("------ ");
                }
                Console.WriteLine();
                for (int i = 0; i < SIZE; i++)
                {
                    Console.Write("[{0,2} ] ", i);
                    for (int j = 0; j < SIZE; j++)
                    {
                        Console.Write("|{0,3} | ", arr[i, j]);
                    }
                    Console.WriteLine();
                    Console.Write("----- ");
                    for (int j = 0; j < SIZE; j++)
                    {
                        Console.Write("------ ");
                    }
                    Console.WriteLine();
                }
                /*---------------------------------------------*/
                /* Реализация алгоритма Дейкстры*/
                int[] d = new int[SIZE];
                int[] v = new int[SIZE];

                for (int i = 0; i < SIZE; i++)
                {
                    d[i] = 10000;
                }
                d[0] = 0;

                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 1; j < SIZE; j++)
                    {
                        if (arr[i, j] != 0 && (arr[i, j] + d[i]) < d[j])
                        {
                            d[j] = (arr[i, j] + d[i]);

                            if (j < i)
                                i = j;
                        }
                    }
                }
                int last = SIZE - 1;

                List<int> vector = new List<int>();
                vector.Add(last);
                while (last > 0)
                {
                    for (int i = 0; i < SIZE; i++)
                    {
                        if (arr[last, i] != 0)
                        {
                            int temp = d[last] - arr[last, i];
                            if (temp == d[i])
                            {
                                vector.Add(i);
                                last = i;
                            }
                        }
                    }
                }
                vector.Reverse();
                Console.WriteLine("Кратчайший путь: ");
                for (int i = 0; i < vector.Count(); i++)
                {
                    Console.Write(vector[i]);
                    if ((i + 1) < vector.Count())
                        Console.Write("-");
                }
                Console.ReadKey(true);

                Console.WriteLine();
                Console.WriteLine("Длина кратчайшего пути: " + d[SIZE - 1]);

                Console.ReadKey(true);

                Console.WriteLine("Кратчайший путь в каждую верщину: ");
                for (int i = 0; i < SIZE; i++)
                    Console.WriteLine(i + ": " + d[i]);
                Console.ReadKey();
            }
        }
    }
}
