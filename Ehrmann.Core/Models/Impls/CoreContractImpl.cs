using System;
using System.Collections.Generic;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Models.Impls
{
    internal class CoreContractImpl : ICoreContract
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<ICoreArticleGroup> ArticleGroups { get; set; }
    }
}