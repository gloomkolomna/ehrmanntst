using System.Collections.Generic;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEhrmannCore
    {
        /// <summary>
        /// Возвращает контракт по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор контракта</param>
        /// <returns>Контракт</returns>
        ICoreContract GetContract(int id);

        /// <summary>
        /// Возвращает список всех контрактов
        /// </summary>
        /// <returns>Контракты</returns>
        IEnumerable<ICoreContract> GetContracts();

        /// <summary>
        /// Создание контракта
        /// </summary>
        ICoreContract CreateContract();

        /// <summary>
        /// Обновление контракта
        /// </summary>
        /// <param name="contract">Контракт</param>
        void UpdateContract(ICoreContract contract);

        /// <summary>
        /// Удаление контракта
        /// </summary>
        /// <param name="id">Идентификатор контракта для удаления</param>
        void DeleteContract(int id);
    }
}