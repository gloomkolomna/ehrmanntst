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

        public ICoreContract CreateContract()
        {
            throw new System.NotImplementedException();
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