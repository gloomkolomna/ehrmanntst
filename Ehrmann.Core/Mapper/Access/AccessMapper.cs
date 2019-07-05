using System;
using System.Collections.Generic;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Mapper.Access
{
    internal class AccessMapper : IMapper
    {
        private string _connection;

        public AccessMapper(string connection)
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

        public void UpdateContract(ICoreContract contract)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteContract(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}