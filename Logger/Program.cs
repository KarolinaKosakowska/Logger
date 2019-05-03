using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = null;
            bool tryItAgain = true;
            try
            {
                while (tryItAgain)
                {
                    tryItAgain = false;
                    Console.WriteLine("Wybierz 1 aby rozpocząć");
                    ConsoleKeyInfo start = Console.ReadKey(true);
                    if (start.Key == ConsoleKey.D1 || start.Key == ConsoleKey.NumPad1)
                    {
                        Console.WriteLine("Podaj nazwę pliku docelowego");
                        fileName = Console.ReadLine();
                        fileName = fileName.Replace(" ", "_");
                        int numberOfDataEnters = 0;
                        try
                        {
                            Console.WriteLine("Ile danych chcesz wpisać?");
                            numberOfDataEnters = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Błędna wartość, podaj liczę całkowitą");
                            numberOfDataEnters = int.Parse(Console.ReadLine());
                            if (numberOfDataEnters == 0)
                            {
                                throw;
                            }

                        }

                        int count = 0;
                        FileLogger.Logger info = new FileLogger.LogInfo($"{fileName}.txt");

                        while (count < numberOfDataEnters)
                        {
                            Console.WriteLine("Podaj dane");
                            var text = Console.ReadLine();
                            count++;
                            info.Log(text);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wybrano błędny klawisz, wybierz 1");
                        tryItAgain = true;
                    }

                }

            }
            catch (NullReferenceException nre)
            {
                FileLogger.Logger error = new FileLogger.LogError($"{fileName}.txt");
                error.Log(nre);
            }
            catch (Exception exc)
            {
                fileName = fileName ?? "Error";
                FileLogger.Logger error = new FileLogger.LogError($"{fileName}.txt");
                error.Log(exc);
            }
        }
    }
}
