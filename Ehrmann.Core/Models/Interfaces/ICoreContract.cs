using System;
using System.Collections.Generic;

namespace Ehrmann.Core.Models.Interfaces
{
    /// <summary>
    /// Контракт
    /// </summary>
    public interface ICoreContract : ICoreItem
    {
        /// <summary>
        /// Дата с
        /// </summary>
        DateTime StartDate { get; set; }
        /// <summary>
        /// Дата по
        /// </summary>
        DateTime EndDate { get; set; }
        /// <summary>
        /// Артикульные группы
        /// </summary>
        IEnumerable<ICoreArticleGroup> ArticleGroups { get; set; }
    }
}