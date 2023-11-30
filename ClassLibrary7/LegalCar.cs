using System;

namespace ClassLibrary7
{
    /// <summary>
    /// Представляет класс для юридического лица (юридического владельца) владеющего автомобилем.
    /// </summary>
    public class LegalCar : Car
    {
        /// <summary>
        /// Получает или задает информацию о юридическом владельце автомобиля.
        /// </summary>
        public LegalOwner Owner { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LegalCar"/>.
        /// </summary>
        /// <param name="productionDate">Дата производства автомобиля.</param>
        /// <param name="mileage">Пробег автомобиля.</param>
        /// <param name="brand">Марка автомобиля.</param>
        /// <param name="bodyType">Тип кузова автомобиля.</param>
        /// <param name="lastTechnicalInspectionDate">Дата последнего технического осмотра автомобиля.</param>
        /// <param name="owner">Информация о юридическом владельце автомобиля.</param>
        public LegalCar(DateTime productionDate, double mileage, string brand, string bodyType, DateTime lastTechnicalInspectionDate, LegalOwner owner)
            : base(productionDate, mileage, brand, bodyType, OwnerType.Legal, lastTechnicalInspectionDate)
        {
            Owner = owner;
        }

        public override string GetInspectionFrequency()
        {
            return "Раз в полгода";
        }
    }
}
