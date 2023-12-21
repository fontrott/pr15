using System;

class Program
{
    struct Enterprise
    {
        public string name;
        public string specialty;
        public int averageAge;
        public double averageSalary;

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Здравствуйте!");
                Console.Write("Для запуска программы нажмите Y, для предварительного выхода нажмите N: ");
                string select_key = Console.ReadLine();
                switch (select_key)
                {
                    case "Y":
                        try
                        {
                            int n;
                            Console.Write("Введите количество предприятий: ");
                            n = int.Parse(Console.ReadLine());
                            do
                            {
                                if (n == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Количество предприятий не может быть равно нулю. Пожалуйста, введите ещё раз.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("Введите количество предприятий: ");
                                    n = int.Parse(Console.ReadLine());
                                }
                                if (n < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Количество предприятий не может быть меньше нуля. Пожалуйста, введите ещё раз.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("Введите количество предприятий: ");
                                    n = int.Parse(Console.ReadLine());
                                }
                            }
                            while (n < 0 || n == 0);

                            Enterprise[] enterprises = new Enterprise[n];

                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine($"\nВведите информацию о предприятии {i + 1}:");

                                Console.Write("Название предприятия: ");
                                enterprises[i].name = Console.ReadLine();

                                Console.Write("Специальность: ");
                                enterprises[i].specialty = Console.ReadLine();

                                Console.Write("Средний возраст сотрудников данной специальности: ");
                                enterprises[i].averageAge = int.Parse(Console.ReadLine());

                                Console.Write("Средний оклад: ");
                                enterprises[i].averageSalary = double.Parse(Console.ReadLine());
                            }

                            Console.WriteLine("\nИнформация о предприятиях:");

                            int locksmithCount = 0;
                            int turnerCount = 0;
                            string mostCommonSpecialty = "";
                            int maxSpecialtyCount = 0;

                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine($"\nПредприятие {i + 1}:");
                                Console.WriteLine($"Название: {enterprises[i].name}");
                                Console.WriteLine($"Специальность: {enterprises[i].specialty}");
                                Console.WriteLine($"Средний возраст сотрудников: {enterprises[i].averageAge}");
                                Console.WriteLine($"Средний оклад: {enterprises[i].averageSalary}");

                                if (enterprises[i].specialty == "слесарь")
                                    locksmithCount++;
                                else if (enterprises[i].specialty == "токарь")
                                    turnerCount++;

                                int specialtyCount = CountSpecialty(enterprises, enterprises[i].specialty);
                                if (specialtyCount > maxSpecialtyCount)
                                {
                                    mostCommonSpecialty = enterprises[i].specialty;
                                    maxSpecialtyCount = specialtyCount;
                                }
                            }

                            Console.WriteLine("\nИнформация о количестве слесарей и токарей:");
                            Console.WriteLine($"Количество слесарей: {locksmithCount}");
                            Console.WriteLine($"Количество токарей: {turnerCount}");

                            if (locksmithCount == 0 && turnerCount == 0) Console.WriteLine("На предприятиях нет слесарей и токарей.");

                            Console.WriteLine($"\nСамая распространенная специальность:{mostCommonSpecialty}, {mostCommonSpecialty}");
                            Console.ReadKey();
                        }
                        catch (FormatException fe)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Упс... что-то пошло не так " + fe.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Упс... что-то пошло не так " + ex.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case "N":
                        Console.Write("До свидания!");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public static int CountSpecialty(Enterprise[] enterprises, string specialty)
        {
            int count = 0;
            foreach (Enterprise enterprise in enterprises)
            {
                if (enterprise.specialty == specialty)
                    count++;
            }
            return count;
        }
    }
}