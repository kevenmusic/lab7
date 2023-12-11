using System;

namespace ClassLibrary7
{
    /// <summary>
    /// Представляет тип владельца автомобиля (Физическое или Юридическое лицо).
    /// </summary>
    public enum OwnerType
    {
        /// <summary>
        /// Физическое лицо.
        /// </summary>
        Individual,

        /// <summary>
        /// Юридическое лицо.
        /// </summary>
        Legal
    }

    /// <summary>
    /// Представляет базовый класс для автомобиля.
    /// </summary>
    public abstract class Car
    {
        /// <summary>
        /// Получает или задает дату производства автомобиля.
        /// </summary>
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// Получает или задает пробег автомобиля.
        /// </summary>
        public double Mileage { get; set; }

        /// <summary>
        /// Получает или задает марку автомобиля.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Получает или задает тип кузова автомобиля.
        /// </summary>
        public string BodyType { get; set; }

        /// <summary>
        /// Получает или задает тип владельца автомобиля (Физическое или Юридическое лицо).
        /// </summary>
        public OwnerType OwnerType { get; set; }

        /// <summary>
        /// Получает или задает дату последнего технического осмотра автомобиля.
        /// </summary>
        public DateTime LastTechnicalInspectionDate { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Car"/>.
        /// </summary>
        /// <param name="productionDate">Дата производства автомобиля.</param>
        /// <param name="mileage">Пробег автомобиля.</param>
        /// <param name="brand">Марка автомобиля.</param>
        /// <param name="bodyType">Тип кузова автомобиля.</param>
        /// <param name="ownerType">Тип владельца автомобиля (Физическое или Юридическое лицо).</param>
        /// <param name="lastTechnicalInspectionDate">Дата последнего технического осмотра автомобиля.</param>
        protected Car(DateTime productionDate, double mileage, string brand, string bodyType, OwnerType ownerType, DateTime lastTechnicalInspectionDate)
        {
            if (mileage < 0)
            {
                throw new CarException("Пробег не может быть отрицательным.");
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new CarException("Марка автомобиля не может быть пустой или содержать только пробелы.");
            }

            if (productionDate > lastTechnicalInspectionDate)
            {
                throw new CarException("Дата производства не может быть больше чем дата последнего тех.осмотра.");
            }

            ProductionDate = productionDate;
            Mileage = mileage;
            Brand = brand;
            BodyType = bodyType;
            OwnerType = ownerType;
            LastTechnicalInspectionDate = lastTechnicalInspectionDate;
        }

        public abstract string GetInspectionFrequency();
    }
}
