using System;
using System.Collections.Generic;
using Ehrmann.Core.Mapper;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core
{
    internal class Erhmann : IEhrmannCore
    {
        private readonly IMapper _mapper;

        public Erhmann(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ICoreContract GetContract(int id)
        {
            return _mapper.GetContract(id);
        }

        public IEnumerable<ICoreContract> GetContracts()
        {
            return _mapper.GetContracts();
        }

        public ICoreContract CreateContract(string name, DateTime startDate, DateTime endDate)
        {
            return _mapper.CreateContract(name, startDate, endDate);
        }

        public ICoreContract UpdateContract(ICoreContract contract)
        {
            return _mapper.UpdateContract(contract);
        }

        public bool DeleteContract(ICoreContract contract)
        {
            return _mapper.DeleteContract(contract);
        }

        public ICoreArticleGroup GetArticleGroup(int id)
        {
            return _mapper.GetArticleGroup(id);
        }

        public IEnumerable<ICoreArticleGroup> GetArticleGroups(ICoreContract contract)
        {
            return _mapper.GetArticleGroups(contract);
        }

        public ICoreArticleGroup CreateArticleGroup(ICoreContract contract, string name)
        {
            return _mapper.CreateArticleGroup(contract, name);
        }

        public ICoreArticleGroup UpdateArticleGroup(ICoreArticleGroup articleGroup)
        {
            return _mapper.UpdateArticleGroup(articleGroup);
        }

        public bool DeleteArticleGroup(ICoreArticleGroup articleGroup)
        {
            return _mapper.DeleteArticleGroup(articleGroup);
        }

        public ICoreConditionType GetConditionType(int id)
        {
            return _mapper.GetConditionType(id);
        }

        public IEnumerable<ICoreConditionType> GetConditionTypes(ICoreArticleGroup articleGroup)
        {
            return _mapper.GetConditionTypes(articleGroup);
        }

        public ICoreConditionType CreateConditionType(ICoreArticleGroup articleGroup, string name, int retro, int retroDistr, int rku, int rkuDistr)
        {
            return _mapper.CreateConditionType(articleGroup, name, retro, retroDistr, rku, rkuDistr);
        }

        public ICoreConditionType UpdateConditionType(ICoreConditionType conditionType)
        {
            return _mapper.UpdateConditionType(conditionType);
        }

        public bool DeleteConditionType(ICoreConditionType conditionType)
        {
            return _mapper.DeleteConditionType(conditionType);
        }
    }
}