using System;
using System.Collections.Generic;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Mapper.Excel
{
    internal class ExcelMapper : IMapper
    {
        private string _connection;

        public ExcelMapper(string connection)
        {
            _connection = connection;
        }

        public ICoreContract GetContract(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ICoreContract> GetContracts()
        {
            throw new System.NotImplementedException();
        }

        public ICoreContract CreateContract(string name, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
        
        public ICoreContract UpdateContract(ICoreContract contract)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteContract(ICoreContract contract)
        {
            throw new System.NotImplementedException();
        }

        public ICoreArticleGroup GetArticleGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICoreArticleGroup> GetArticleGroups(ICoreContract contract)
        {
            throw new NotImplementedException();
        }

        public ICoreArticleGroup CreateArticleGroup(ICoreContract contract, string name)
        {
            throw new NotImplementedException();
        }

        public ICoreArticleGroup UpdateArticleGroup(ICoreArticleGroup articleGroup)
        {
            throw new NotImplementedException();
        }

        public bool DeleteArticleGroup(ICoreArticleGroup articleGroup)
        {
            throw new NotImplementedException();
        }

        public ICoreConditionType GetConditionType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICoreConditionType> GetConditionTypes(ICoreArticleGroup articleGroup)
        {
            throw new NotImplementedException();
        }

        public ICoreConditionType CreateConditionType(ICoreArticleGroup articleGroup, string name, int retro, int retroDistr, int rku, int rkuDistr)
        {
            throw new NotImplementedException();
        }

        public ICoreConditionType UpdateConditionType(ICoreConditionType conditionType)
        {
            throw new NotImplementedException();
        }

        public bool DeleteConditionType(ICoreConditionType conditionType)
        {
            throw new NotImplementedException();
        }
    }
}