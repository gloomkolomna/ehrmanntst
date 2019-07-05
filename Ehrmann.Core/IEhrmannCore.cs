using System;
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
        /// <param name="name">Название</param>
        /// <param name="startDate">Начало контракта</param>
        /// <param name="endDate">Окончание контракта</param>
        ICoreContract CreateContract(string name, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Обновление контракта
        /// </summary>
        /// <param name="contract">Контракт</param>
        /// <returns>Обновленный контракт</returns>
        ICoreContract UpdateContract(ICoreContract contract);

        /// <summary>
        /// Удаление контракта
        /// </summary>
        /// <param name="id">Идентификатор контракта для удаления</param>
        /// <returns><c>true</c> если операция прошла успешно, <c>false</c> - в случае неудачи</returns>
        bool DeleteContract(int id);
    }
}