using System;

class Program
{
    struct Company // создание структуры
    {
        public string Name; // название предприятия
        public string Specialty; // название специальности
        public int AvgAge; // средний возраст
        public int AvgSalary; // средний оклад
    }
    static Company InputCompanyInfo() // метод для ввода данных о предприятиях
    {
        Company company;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Название предприятия: "); 
        company.Name = Console.ReadLine();
        do
        {
            if (String.IsNullOrEmpty(company.Name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Предприятие не может быть без названия. Введите ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Название предприятия: ");
                company.Name = Console.ReadLine();
            }
        }
        while (String.IsNullOrEmpty(company.Name)); // ошибка при вводе пустой строки
        Console.Write("Специальность: ");
        company.Specialty = Console.ReadLine();
        do
        {
            if (String.IsNullOrEmpty(company.Specialty))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Специальность должна иметь название. Введите ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Специальность: ");
                company.Specialty = Console.ReadLine();
            }
        }
        while (String.IsNullOrEmpty(company.Specialty)); // ошибка при вводе пустой строки
        Console.Write("Средний возраст сотрудников данной специальности: ");
        company.AvgAge = Int32.Parse(Console.ReadLine());
        do
        {
            if (company.AvgAge < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Средний возраст не может быть меньше нуля. Введите ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Средний возраст сотрудников данной специальности: ");
                company.AvgAge = Int32.Parse(Console.ReadLine());
            }
            if (company.AvgAge == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Средний возраст не может быть равен нулю. Введите ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Средний возраст сотрудников данной специальности: ");
                company.AvgAge = Int32.Parse(Console.ReadLine());
            }
        }
        while (company.AvgAge < 0 || company.AvgAge == 0); // ошибка при значении меньше нуля либо равное нулю
        Console.Write("Средний оклад: ");
        company.AvgSalary = Int32.Parse(Console.ReadLine());
        do
        {
            if (company.AvgSalary < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Средний оклад не может быть отрицательным. Введите ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Средний оклад: ");
                company.AvgSalary = Int32.Parse(Console.ReadLine());
            }
            if (company.AvgSalary == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Средний оклад не может быть равен нулю. Введите ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Средний оклад: ");
                company.AvgSalary = Int32.Parse(Console.ReadLine()); 
            }
        }
        while (company.AvgSalary < 0 || company.AvgSalary == 0); // ошибка при значении меньше нуля либо равное нулю
        return company;
    }

    static void DisplayCompaniesInfo(Company[] companies) // метод для вывода данных о предприятиях
    {
        Console.ForegroundColor = ConsoleColor.White;
        foreach (Company company in companies)
        {
            Console.WriteLine("\nНазвание предприятия: {0}", company.Name);
            Console.WriteLine("Специальность: {0}", company.Specialty);
            Console.WriteLine("Средний возраст сотрудников данной специальности: {0}", company.AvgAge);
            Console.WriteLine("Средний оклад: {0}", company.AvgSalary);
        }
    }

    static int CountSpecialists(Company[] companies, string specialty) // метод для подсчёта количества работников каждой введённой специальности
    {
        int count = 0;
        foreach (Company company in companies) // цикл для перебора
        {
            if (company.Specialty == specialty)
                count++;
        }
        return count;
    }

    static void DisplayTopSpecialty(Company[] companies) // метод для определения самой популярной специальности
    {
        Console.WriteLine("\nИнформация о предприятиях:"); 
        int locksmithCount = 0; // количество слесарей
        int turnerCount = 0; // количество токарей
        string mostCommonSpecialty = ""; // наименование самой популярной специальности
        int maxSpecialtyCount = 0; // самое большое количество по специальностям
        foreach (Company company in companies) // цикл для перебора
        {
            if (company.Specialty == "Слесарь" || company.Specialty == "слесарь") locksmithCount++;
            else if (company.Specialty == "Токарь" || company.Specialty == "токарь") turnerCount++;
            if (company.Specialty != mostCommonSpecialty)
            {
                int specialtyCount = CountSpecialists(companies, company.Specialty);
                if (specialtyCount > maxSpecialtyCount)
                {
                    maxSpecialtyCount = specialtyCount;
                    mostCommonSpecialty = company.Specialty;
                }
                else if (specialtyCount == maxSpecialtyCount)
                {
                    mostCommonSpecialty = "Нет самой популярной специальности.";
                }
            }
        }
        Console.WriteLine("\nИнформация о количестве слесарей и токарей:");
        Console.WriteLine($"Количество слесарей: {locksmithCount}");
        Console.WriteLine($"Количество токарей: {turnerCount}");
        if (locksmithCount == 0 && turnerCount == 0) Console.WriteLine("На предприятиях нет слесарей и токарей.");
        else if (mostCommonSpecialty == "Нет самой популярной специальности.") Console.WriteLine("\nНет самой популярной специальности, так как все специальности по количеству равны между собой.");
        else Console.WriteLine($"\nСамая распространенная специальность: {mostCommonSpecialty}");
        Console.ReadKey();
    }
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        int n;
        Console.Write("Введите количество предприятий: ");
        n = Int32.Parse(Console.ReadLine());
        do
        {
            if (n < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Количество предприятий не может быть отрицательным. Введите ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите количество предприятий: ");
                n = Int32.Parse(Console.ReadLine());
            }
            if (n == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Количество предприятий не может быть равным нулю. Введите ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите количество предприятий: ");
                n = Int32.Parse(Console.ReadLine());
            }
        }
        while (n < 0 || n == 0);
        Company[] companies = new Company[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nВведите информацию о предприятии {0}:", i + 1);

            companies[i] = InputCompanyInfo();
        }

        Console.WriteLine("\nИнформация о предприятиях:");
        DisplayCompaniesInfo(companies);

        int numberOfLocksmiths = CountSpecialists(companies, "слесарь");
        int numberOfTurners = CountSpecialists(companies, "токарь");

        Console.WriteLine("\nКоличество слесарей: {0}", numberOfLocksmiths);
        Console.WriteLine("Количество токарей: {0}", numberOfTurners);

        DisplayTopSpecialty(companies);
        Console.ReadKey();
    }
}
