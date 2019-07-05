using System.Collections.Generic;
using System.Linq;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Models.Impls
{
    internal class CoreArticleGroupImpl : ICoreArticleGroup
    {
        public int Retro
        {
            get
            {
                return ConditionTypes.Sum(conditionType => conditionType.Retro); ;
            }
            set { }
        }

        public int RetroDistr
        {
            get
            {
                return ConditionTypes.Sum(conditionType => conditionType.RetroDistr);
            }
            set { }
        }
        public int Rku
        {
            get
            {
                return ConditionTypes.Sum(conditionType => conditionType.Rku);
            }
            set { }
        }
        public int RkuDistr
        {
            get
            {
                return ConditionTypes.Sum(conditionType => conditionType.RkuDistr);
            }
            set { }
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ICoreConditionType> ConditionTypes { get; set; }
    }
}