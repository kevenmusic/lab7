using ClassLibrary7;
using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[]
            {
                new IndividualCar(new DateTime(2010, 1, 1), 50000, "Toyota", "Sedan", new DateTime(2022, 1, 1), new IndividualOwner("John Doe")),
                new LegalCar(new DateTime(2015, 5, 1), 30000, "Ford", "SUV", new DateTime(2022, 6, 1), new LegalOwner("ABC Company")),
                new IndividualCar(new DateTime(2012, 3, 15), 80000, "Chevrolet", "Hatchback", new DateTime(2021, 5, 10), new IndividualOwner("Jane Smith")),
                new LegalCar(new DateTime(2018, 7, 20), 40000, "Honda", "Sedan", new DateTime(2022, 2, 28), new LegalOwner("XYZ Corporation")),
                new IndividualCar(new DateTime(2011, 11, 7), 70000, "Nissan", "SUV", new DateTime(2022, 4, 5), new IndividualOwner("Bob Johnson")),
                new LegalCar(new DateTime(2016, 6, 12), 35000, "Mazda", "Coupe", new DateTime(2022, 3, 15), new LegalOwner("DEF Ltd.")),
                new IndividualCar(new DateTime(2009, 9, 30), 90000, "Volkswagen", "Sedan", new DateTime(2021, 8, 20), new IndividualOwner("Alice Williams")),
                new LegalCar(new DateTime(2014, 4, 5), 60000, "Hyundai", "SUV", new DateTime(2021, 11, 18), new LegalOwner("GHI Enterprises")),
                new IndividualCar(new DateTime(2019, 12, 10), 75000, "Kia", "Hatchback", new DateTime(2022, 5, 10), new IndividualOwner("Charlie Brown")),
                new IndividualCar(new DateTime(2017, 8, 25), 65000, "Mercedes", "Coupe", new DateTime(2022, 3, 8), new IndividualOwner("Eva Green")),
                new LegalCar(new DateTime(2019, 10, 15), 5000, "BMW", "SUV", new DateTime(2022, 1, 15), new LegalOwner("JKL Group")),
                new LegalCar(new DateTime(2017, 6, 1), 45000, "Audi", "Sedan", new DateTime(2021, 10, 5), new LegalOwner("LMN Corporation")),
                new LegalCar(new DateTime(2020, 2, 28), 3000, "Tesla", "Coupe", new DateTime(2022, 4, 20), new LegalOwner("OPQ Enterprises")),
                new LegalCar(new DateTime(2018, 4, 12), 25000, "Volvo", "Sedan", new DateTime(2022, 2, 10), new LegalOwner("RST Ltd.")),
                new LegalCar(new DateTime(2016, 11, 5), 18000, "Jaguar", "Coupe", new DateTime(2021, 9, 15), new LegalOwner("UVW Group")),
                new LegalCar(new DateTime(2015, 7, 20), 35000, "Lexus", "SUV", new DateTime(2021, 12, 30), new LegalOwner("XYZ Corporation"))
            };

            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------------------------|");
                Console.WriteLine("|                                Меню:                                 |");
                Console.WriteLine("| 1. Вывести физические лица, которым необходимо проходить техосмотр.  |");
                Console.WriteLine("| 2. Вывести юридические лица, которым необходимо проходить техосмотр. |");
                Console.WriteLine("| 3. Вывести количество автомобилей по типу кузова для юридических лиц.|");
                Console.WriteLine("|        4. Вывести всю информацию о всех автомобилях.                 |");
                Console.WriteLine("|                     5. Ввод информации вручную                       |");
                Console.WriteLine("|                              6. Выйти.                               |");
                Console.WriteLine("|----------------------------------------------------------------------|");

                Console.Write("Выберите опцию (1-5): ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        PrintAllCars(cars);

                        string text = "Физические лица, которым необходимо проходить техосмотр";
                        int leftPadding = 50; // Количество пробелов слева
                        int rightPadding = 47; // Количество пробелов справа

                        string indentedText = text.PadLeft(text.Length + leftPadding).PadRight(text.Length + leftPadding + rightPadding);

                        Console.WriteLine($"| {indentedText} |");
                        Console.WriteLine("|" + new string('-', 154) + "|");

                        foreach (var car in cars)
                        {
                            if (car is IndividualCar individualCar)
                            {
                                try
                                {
                                    string inspectionFrequency = individualCar.GetInspectionFrequency();

                                    Console.WriteLine($"| Марка: {car.Brand,-10} | Владелец: {individualCar.Owner.IndividualName,-14} " +
                                                      $"| Дата производства: {car.ProductionDate.ToShortDateString(),-10} " +
                                                      $"| Пробег: {car.Mileage,-5} км " +
                                                      $"| Тип кузова: {car.BodyType,-9} " +
                                                      $"| Требуется осмотр: {inspectionFrequency,-12} |");
                                }
                                catch (CarException ex)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }
                                catch (IndividualCarException ex)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }
                                catch (LegalCarException ex)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }
                            }
                        }

                        Console.WriteLine("|" + new string('-', 154) + "|");
                        Console.Write("Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        PrintAllCars(cars);
                        PrintAllCars(cars, showLegalCarsOnly: true);
                        Console.Write("Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();

                        PrintAllCars(cars, showLegalCarsOnly: true);

                        string[] bodyTypes =
                        {
                            "Sedan",
                            "SUV",
                            "Hatchback",
                            "Coupe"
                        };

                        int[] legalCarsCountByBodyType = new int[bodyTypes.Length];

                        foreach (var car in cars)
                        {
                            if (car is LegalCar legalCar)
                            {
                                string bodyType = legalCar.BodyType;
                                Regex regex = new Regex($"^{bodyType}$", RegexOptions.IgnoreCase);

                                for (int i = 0; i < bodyTypes.Length; i++)
                                {
                                    if (regex.IsMatch(bodyTypes[i]))
                                    {
                                        legalCarsCountByBodyType[i]++;
                                        break;
                                    }
                                }
                            }
                        }

                        Console.WriteLine("Количество автомобилей по типу кузова для юридических лиц:");
                        Console.WriteLine("|" + new string('-', 18) + "|");

                        for (int i = 0; i < bodyTypes.Length; i++)
                        {
                            Console.WriteLine($"| {bodyTypes[i],-9}: {legalCarsCountByBodyType[i]} шт. |");
                        }

                        Console.WriteLine("|" + new string('-', 18) + "|");
                        Console.Write("Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        PrintAllCars(cars);
                        
                        Console.Write("Нажмите Enter для возврата в меню...");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Write("Выберите тип владельца (1 - Физическое лицо, 2 - Юридическое лицо): ");
                        int ownerTypeChoice = int.Parse(Console.ReadLine());

                        Console.Write("Введите количество записей: ");
                        int recordCount = int.Parse(Console.ReadLine());

                        cars = new Car[recordCount];

                        for (int i = 0; i < recordCount; i++)
                        {
                            try
                            {
                                if (ownerTypeChoice == 1)
                                {
                                    // Ввод параметров для IndividualOwner
                                    Console.Write($"Введите имя физического владельца {i + 1}: ");
                                    string individualName = Console.ReadLine();

                                    // Создание экземпляра IndividualOwner
                                    IndividualOwner individualOwner = new IndividualOwner(individualName);

                                    // Ввод параметров для IndividualCar
                                    Console.Write($"Введите дату производства автомобиля {i + 1} (ГГГГ-ММ-ДД): ");
                                    DateTime productionDate = DateTime.Parse(Console.ReadLine());

                                    Console.Write($"Введите пробег автомобиля {i + 1}: ");
                                    double mileage = double.Parse(Console.ReadLine());

                                    Console.Write($"Введите марку автомобиля {i + 1}: ");
                                    string brand = Console.ReadLine();

                                    Console.Write($"Введите тип кузова автомобиля {i + 1}: ");
                                    string bodyType = Console.ReadLine();

                                    Console.Write($"Введите дату последнего технического осмотра автомобиля {i + 1} (ГГГГ-ММ-ДД): ");
                                    DateTime lastTechnicalInspectionDate = DateTime.Parse(Console.ReadLine());

                                    // Создание экземпляра IndividualCar
                                    cars[i] = new IndividualCar(productionDate, mileage, brand, bodyType, lastTechnicalInspectionDate, individualOwner);
                                }
                                else if (ownerTypeChoice == 2)
                                {
                                    // Ввод параметров для LegalOwner
                                    Console.Write($"Введите название компании юридического владельца {i + 1}: ");
                                    string legalName = Console.ReadLine();

                                    // Создание экземпляра LegalOwner
                                    LegalOwner legalOwner = new LegalOwner(legalName);

                                    // Ввод параметров для LegalCar
                                    Console.Write($"Введите дату производства юридического автомобиля {i + 1} (ГГГГ-ММ-ДД): ");
                                    DateTime productionDate = DateTime.Parse(Console.ReadLine());

                                    Console.Write($"Введите пробег юридического автомобиля {i + 1}: ");
                                    double mileage = double.Parse(Console.ReadLine());

                                    Console.Write($"Введите марку юридического автомобиля {i + 1}: ");
                                    string brand = Console.ReadLine();

                                    Console.Write($"Введите тип кузова юридического автомобиля {i + 1}: ");
                                    string bodyType = Console.ReadLine();

                                    Console.Write($"Введите дату последнего технического осмотра юридического автомобиля {i + 1} (ГГГГ-ММ-ДД): ");
                                    DateTime lastTechnicalInspectionDate = DateTime.Parse(Console.ReadLine());

                                    // Создание экземпляра LegalCar
                                    cars[i] = new LegalCar(productionDate, mileage, brand, bodyType, lastTechnicalInspectionDate, legalOwner);
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный выбор типа владельца. Программа завершена.");
                                    return;
                                }
                            }
                            catch (CarException ex)
                            {
                                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                            }
                            catch (IndividualCarException ex)
                            {
                                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                            }
                            catch (LegalCarException ex)
                            {
                                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                            Console.Write("Нажмите Enter для возврата в меню...");
                            Console.ReadLine();
                        }
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static string GetOwnerInfo(Car car)
        {
            if (car is IndividualCar individualCar)
            {
                return individualCar.Owner.IndividualName;
            }
            else if (car is LegalCar legalCar)
            {
                return legalCar.Owner.LegalName;
            }
            else
            {
                return "Неизвестный владелец";
            }
        }

        static void PrintAllCars(Car[] cars)
        {
            try
            {
                Console.WriteLine("|" + new string('-', 154) + "|");
                string text = "Все автомомбили";
                int leftPadding = 70;
                int rightPadding = 67;

                string indentedText = text.PadLeft(text.Length + leftPadding).PadRight(text.Length + leftPadding + rightPadding);

                Console.WriteLine($"| {indentedText} |");
                Console.WriteLine("|" + new string('-', 154) + "|");
                foreach (var car in cars)
                {
                    Console.WriteLine($"| Марка: {car.Brand,-10} | Тип кузова: {car.BodyType,-9} " +
                                      $"| Пробег: {car.Mileage,-5} км | Дата производства: {car.ProductionDate.ToShortDateString(),-10} " +
                                      $"| Последний осмотр: {car.LastTechnicalInspectionDate.ToShortDateString(),-10} " +
                                      $"| Владелец: {GetOwnerInfo(car),-16} |");
                }
                Console.WriteLine("|" + new string('-', 154) + "|");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        static void PrintAllCars(Car[] cars, bool showLegalCarsOnly = false)
        {
            string text = "Юридические лица, которым необходимо проходить техосмотр";
            int leftPadding = 50;
            int rightPadding = 46;
            string indentedText = text.PadLeft(text.Length + leftPadding).PadRight(text.Length + leftPadding + rightPadding);
            Console.WriteLine($"| {indentedText} |");
            Console.WriteLine("|" + new string('-', 154) + "|");

            foreach (var car in cars)
            {
                if (car is LegalCar legalCar)
                {
                    string inspectionFrequency = legalCar.GetInspectionFrequency();

                    Console.WriteLine($"| Марка: {car.Brand,-10} | Владелец: {legalCar.Owner.LegalName,-15} " +
                                      $"| Дата производства: {car.ProductionDate.ToShortDateString(),-10} " +
                                      $"| Пробег: {car.Mileage,-5} км " +
                                      $"| Тип кузова: {car.BodyType,-7} " +
                                      $"| Требуется осмотр: {inspectionFrequency,-10} |");
                }
            }

            Console.WriteLine("|" + new string('-', 154) + "|");
        }
    }
}
