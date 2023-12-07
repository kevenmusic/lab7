namespace ClassLibrary7
{
    /// <summary>
    /// Представляет класс для юридического владельца автомобиля.
    /// </summary>
    public class LegalOwner
    {
        /// <summary>
        /// Получает или задает наименование компании юридического владельца.
        /// </summary>
        public string LegalName { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LegalOwner"/>.
        /// </summary>
        /// <param name="companyName">Наименование компании юридического владельца.</param>
        public LegalOwner(string legalName)
        {
            LegalName = legalName;
        }
    }
}
