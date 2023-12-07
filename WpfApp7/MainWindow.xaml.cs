using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using ClassLibrary7;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        Car[] cars;
        string[] bodyTypes = {
            "Sedan", 
            "SUV", 
            "Hatchback", 
            "Coupe" 
        };

        public MainWindow()
        {
            InitializeComponent();

            cars = new Car[]
            {
                new IndividualCar(new DateTime(2010, 1, 1), 50000, "Toyota", "Sedan", new DateTime(2022, 1, 1), new IndividualOwner("John Doe")),
                new LegalCar(new DateTime(2015, 5, 1), 30000, "Ford", "SUV", new DateTime(2022, 6, 1), new LegalOwner("ABC Company")),
                new IndividualCar(new DateTime(2012, 3, 15), 80000, "Chevrolet", "Hatchback", new DateTime(2021, 5, 10), new IndividualOwner("Jane Smith")),
                new LegalCar(new DateTime(2018, 7, 20), 40000, "Honda", "Sedan", new DateTime(2022, 2, 28), new LegalOwner("XYZ Corporation")),
                new IndividualCar(new DateTime(2011, 11, 7), 70000, "Nissan", "SUV", new DateTime(2022, 4, 5), new IndividualOwner("Bob Johnson")),
                new LegalCar(new DateTime(2016, 6, 12), 35000, "Mazda", "Coupe", new DateTime(2022, 3, 15), new LegalOwner("DEF Ltd.")),
                new IndividualCar(new DateTime(2009, 9, 30), 90000, "Volkswagen", "Sedan", new DateTime(2021, 8, 20), new IndividualOwner("Alice Williams")),
                new LegalCar(new DateTime(2014, 4, 5), 60000, "Hyundai", "SUV", new DateTime(2021, 11, 18), new LegalOwner("GHI Enterprises")),
                new IndividualCar(new DateTime(2018, 12, 10), 75000, "Kia", "Hatchback", new DateTime(2022, 5, 10), new IndividualOwner("Charlie Brown")),
                new IndividualCar(new DateTime(2017, 8, 25), 65000, "Mercedes", "Coupe", new DateTime(2022, 3, 8), new IndividualOwner("Eva Green")),
                new LegalCar(new DateTime(2019, 10, 15), 5000, "BMW", "SUV", new DateTime(2022, 1, 15), new LegalOwner("JKL Group")),
                new LegalCar(new DateTime(2017, 6, 1), 45000, "Audi", "Sedan", new DateTime(2021, 10, 5), new LegalOwner("LMN Corporation")),
                new LegalCar(new DateTime(2020, 2, 28), 3000, "Tesla", "Coupe", new DateTime(2022, 4, 20), new LegalOwner("OPQ Enterprises")),
                new LegalCar(new DateTime(2018, 4, 12), 25000, "Volvo", "Sedan", new DateTime(2022, 2, 10), new LegalOwner("RST Ltd.")),
                new LegalCar(new DateTime(2016, 11, 5), 18000, "Jaguar", "Coupe", new DateTime(2021, 9, 15), new LegalOwner("UVW Group")),
                new LegalCar(new DateTime(2015, 7, 20), 35000, "Lexus", "SUV", new DateTime(2021, 12, 30), new LegalOwner("XYZ Corporation"))
            };
        }

        private void OptionsComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Очистить предыдущий вывод
            outputTextBox.Clear();

            // Получаем выбранную опцию из ComboBox
            ComboBoxItem selectedOption = (ComboBoxItem)optionsComboBox.SelectedItem;

            if (selectedOption == null)
                return;

            // Выполняем действия на основе выбранного варианта
            try
            {
                switch (selectedOption.Content.ToString())
                {
                    case "Физические лица, нуждающиеся в техосмотре":
                        ShowIndividualsRequiringInspection();
                        break;

                    case "Юридические лица, нуждающиеся в техосмотре":
                        ShowLegalEntitiesRequiringInspection();
                        break;

                    case "Количество юридических автомобилей по типу кузова":
                        ShowLegalCarsCountByBodyType();
                        break;
                    case "Все автомобили":
                        ShowAllCars();
                        break;
                }
            }
            catch (CarException ex)
            {
                // Обработка исключений
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowIndividualsRequiringInspection()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                outputTextBox.Text += "Физические лица, которым необходимо проходить техосмотр:\n";

                foreach (var car in cars)
                {
                    if (car.OwnerType == OwnerType.Individual)
                    {
                        IndividualCar individualCar = (IndividualCar)car;
                        string inspectionFrequency = individualCar.GetInspectionFrequency();

                        outputTextBox.Text += $"Марка: {car.Brand}, Владелец: {individualCar.Owner.Name}, " +
                                              $"Дата производства: {car.ProductionDate.ToShortDateString()}, " +
                                              $"Пробег: {car.Mileage} км, " +
                                              $"Тип кузова: {car.BodyType}. \n" +
                                              $"Требуется осмотр: {inspectionFrequency}.\n";
                    }
                }
            }
            catch (CarException ex)
            {
                MessageBox.Show($"Ошибка при обработке физических лиц: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowLegalEntitiesRequiringInspection()
        {
            DateTime currentDate = DateTime.Now;
            outputTextBox.Text += "Юридические лица, которым необходимо проходить техосмотр:\n";

            foreach (var car in cars)
            {
                if (car.OwnerType == OwnerType.Legal)
                {
                    LegalCar legalCar = (LegalCar)car;
                    string inspectionFrequency = legalCar.GetInspectionFrequency();

                    outputTextBox.Text += $"Марка: {car.Brand}, Владелец: {legalCar.Owner.CompanyName}, " +
                                           $"Дата производства: {car.ProductionDate.ToShortDateString()}, " +
                                           $"Пробег: {car.Mileage} км, " +
                                           $"Тип кузова: {car.BodyType}. \n" +
                                           $"Требуется осмотр: {inspectionFrequency}.\n";
                }
            }
        }

        private void ShowLegalCarsCountByBodyType()
        {
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

            outputTextBox.Text += "Количество автомобилей по типу кузова для юридических лиц:\n";
            for (int i = 0; i < bodyTypes.Length; i++)
            {
                outputTextBox.Text += $"{bodyTypes[i]}: {legalCarsCountByBodyType[i]} шт.\n";
            }
        }

        private void ShowAllCars()
        {
            try
            {
                outputTextBox.Text += "Все автомобили:\n";

                foreach (var car in cars)
                {
                    outputTextBox.Text += $"Марка: {car.Brand}, Тип кузова: {car.BodyType}, Пробег: {car.Mileage}, " +
                        $"Дата производства: {car.ProductionDate.ToShortDateString()}, " +
                                         $"Дата последнего техосмотра: {car.LastTechnicalInspectionDate.ToShortDateString()}, " +
                                         $"Владелец: {GetOwnerInfo(car)}\n";
                }
            }
            catch (CarException ex)
            {
                MessageBox.Show($"Ошибка при отображении всех автомобилей: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetOwnerInfo(Car car)
        {
            if (car.OwnerType == OwnerType.Individual)
            {
                return ((IndividualCar)car).Owner.Name;
            }
            else if (car.OwnerType == OwnerType.Legal)
            {
                return ((LegalCar)car).Owner.CompanyName;
            }
            else
            {
                return "Неизвестный владелец";
            }
        }

    }
}
