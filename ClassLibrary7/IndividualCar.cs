using System;

namespace ClassLibrary7
{
    /// <summary>
    /// Представляет класс для физического лица (физического владельца) владеющего автомобилем.
    /// </summary>
    public class IndividualCar : Car
    {
        /// <summary>
        /// Получает или задает информацию о физическом владельце автомобиля.
        /// </summary>
        public IndividualOwner Owner { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IndividualCar"/>.
        /// </summary>
        /// <param name="productionDate">Дата производства автомобиля.</param>
        /// <param name="mileage">Пробег автомобиля.</param>
        /// <param name="brand">Марка автомобиля.</param>
        /// <param name="bodyType">Тип кузова автомобиля.</param>
        /// <param name="lastTechnicalInspectionDate">Дата последнего технического осмотра автомобиля.</param>
        /// <param name="owner">Информация о физическом владельце автомобиля.</param>
        public IndividualCar(DateTime productionDate, double mileage, string brand, string bodyType, DateTime lastTechnicalInspectionDate, IndividualOwner owner)
            : base(productionDate, mileage, brand, bodyType, OwnerType.Individual, lastTechnicalInspectionDate)
        {
            if (owner == null)
            {
                throw new IndividualCarException("Владелец автомобиля не может быть null.");
            }

            Owner = owner;
        }

        /// <summary>
        /// Возвращает информацию о частоте технического осмотра для данного автомобиля.
        /// </summary>
        /// <returns>Строка, указывающая на необходимость осмотра: "Ежегодно" или "Раз в 2 года".</returns>
        public override string GetInspectionFrequency()
        {
            int yearsSinceProduction = DateTime.Now.Year - ProductionDate.Year;
            int inspectionInterval;

            if (yearsSinceProduction >= 10)
            {
                inspectionInterval = 1; // если старше 10 лет, то раз в год
            }
            else
            {
                inspectionInterval = 2; // если младше 10 лет, то раз в 2 года
            }

            if (inspectionInterval == 1)
            {
                return "Ежегодно";
            }
            else
            {
                return "Раз в 2 года";
            }
        }
    }
}
