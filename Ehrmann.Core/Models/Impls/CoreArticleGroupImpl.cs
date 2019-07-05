using System.Collections.Generic;
using System.Linq;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Models.Impls
{
    internal class CoreArticleGroupImpl : ICoreArticleGroup
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ICoreConditionType> ConditionTypes { get; set; }
    }
}