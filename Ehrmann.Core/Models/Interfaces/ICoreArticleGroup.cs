using System.Collections.Generic;

namespace Ehrmann.Core.Models.Interfaces
{
    /// <summary>
    /// Артикульная группа
    /// </summary>
    public interface ICoreArticleGroup : ICoreItem, ICoreValues
    {
        /// <summary>
        /// Виды условий
        /// </summary>
        IEnumerable<ICoreConditionType> ConditionTypes { get; set; }
    }
}