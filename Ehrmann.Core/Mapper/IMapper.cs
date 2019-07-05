using System;
using System.Collections.Generic;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Mapper
{
    internal interface IMapper
    {
        ICoreContract GetContract(int id);
        IEnumerable<ICoreContract> GetContracts();
        ICoreContract CreateContract(string name, DateTime startDate, DateTime endDate);
        ICoreContract UpdateContract(ICoreContract contract);
        bool DeleteContract(ICoreContract contract);
        ICoreArticleGroup GetArticleGroup(int id);
        IEnumerable<ICoreArticleGroup> GetArticleGroups(ICoreContract contract);
        ICoreArticleGroup CreateArticleGroup(ICoreContract contract, string name);
        ICoreArticleGroup UpdateArticleGroup(ICoreArticleGroup articleGroup);
        bool DeleteArticleGroup(ICoreArticleGroup articleGroup);
        ICoreConditionType GetConditionType(int id);
        IEnumerable<ICoreConditionType> GetConditionTypes(ICoreArticleGroup articleGroup);
        ICoreConditionType CreateConditionType(ICoreArticleGroup articleGroup, string name, int retro, int retroDistr, int rku, int rkuDistr);
        ICoreConditionType UpdateConditionType(ICoreConditionType conditionType);
        bool DeleteConditionType(ICoreConditionType conditionType);
    }
}