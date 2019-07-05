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
        #region Contract

        /// <summary>
        /// Возвращает контракт по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
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
        /// <returns>Новый контракт</returns>
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
        /// <param name="contract">Контракт</param>
        /// <returns><c>true</c> если операция прошла успешно, <c>false</c> - в случае неудачи</returns>
        bool DeleteContract(ICoreContract contract);

        #endregion

        #region ArticleGroup

        /// <summary>
        /// Возвращает артикульную группу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Артикульная группа</returns>
        ICoreArticleGroup GetArticleGroup(int id);

        /// <summary>
        /// Возвращает список всех артикульных групп контракта
        /// </summary>
        /// <returns>Артикульные группы контракта</returns>
        IEnumerable<ICoreArticleGroup> GetArticleGroups(ICoreContract contract);

        /// <summary>
        /// Создание артикульной группы
        /// </summary>
        /// <param name="contract">Контракт</param>
        /// <param name="name">Название артикульной группы</param>
        /// <returns>Новая артикульная группа контракта</returns>
        ICoreArticleGroup CreateArticleGroup(ICoreContract contract, string name);

        /// <summary>
        /// Обновление артикульной группы
        /// </summary>
        /// <param name="articleGroup">Артикульная группа</param>
        /// <returns>Обновленная артикульная группа</returns>
        ICoreArticleGroup UpdateArticleGroup(ICoreArticleGroup articleGroup);

        /// <summary>
        /// Удаление артикульной группы
        /// </summary>
        /// <param name="articleGroup">Артикульная группа</param>
        /// <returns><c>true</c> если операция прошла успешно, <c>false</c> - в случае неудачи</returns>
        bool DeleteArticleGroup(ICoreArticleGroup articleGroup);

        #endregion

        #region ConditionType

        /// <summary>
        /// Возвращает виды условий по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Виды условий</returns>
        ICoreConditionType GetConditionType(int id);

        /// <summary>
        /// Возвращает список всех видов условий артикульной группы
        /// </summary>
        /// <returns>Виды условий артикульной группы</returns>
        IEnumerable<ICoreConditionType> GetConditionTypes(ICoreArticleGroup articleGroup);

        /// <summary>
        /// Создание нового вида условий
        /// </summary>
        /// <returns>Новый вид условий артикульной группы</returns>
        ICoreConditionType CreateConditionType(ICoreArticleGroup articleGroup, string name, int retro, int retroDistr, int rku, int rkuDistr);

        /// <summary>
        /// Обновление вида условий
        /// </summary>
        /// <param name="conditionType">Вид условий</param>
        /// <returns>Обновленный вид условий</returns>
        ICoreConditionType UpdateConditionType(ICoreConditionType conditionType);

        /// <summary>
        /// Удаление артикульной группы
        /// </summary>
        /// <param name="conditionType">Вид условий</param>
        /// <returns><c>true</c> если операция прошла успешно, <c>false</c> - в случае неудачи</returns>
        bool DeleteConditionType(ICoreConditionType conditionType);

        #endregion
    }
}