namespace ClassLibrary7
{
    /// <summary>
    /// Представляет класс для физического владельца автомобиля.
    /// </summary>
    public class IndividualOwner
    {
        /// <summary>
        /// Получает или задает имя физического владельца.
        /// </summary>
        public string IndividualName { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IndividualOwner"/>.
        /// </summary>
        /// <param name="name">Имя физического владельца.</param>
        public IndividualOwner(string individualName)
        {
            IndividualName = individualName;
        }
    }
}