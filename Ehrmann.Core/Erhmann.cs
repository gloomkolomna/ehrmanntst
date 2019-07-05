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

        public ICoreContract CreateContract()
        {
            return _mapper.CreateContract();
        }

        public void UpdateContract(ICoreContract contract)
        {
            _mapper.UpdateContract(contract);
        }

        public void DeleteContract(int id)
        {
            _mapper.DeleteContract(id);
        }
    }
}