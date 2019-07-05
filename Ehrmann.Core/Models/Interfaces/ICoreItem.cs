namespace Ehrmann.Core.Models.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICoreItem
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Идентификатор родителя
        /// </summary>
        int OwnerId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; set; }
    }
}