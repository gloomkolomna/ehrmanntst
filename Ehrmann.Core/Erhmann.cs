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

        public bool DeleteContract(int id)
        {
            return _mapper.DeleteContract(id);
        }
    }
}