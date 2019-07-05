using System.Collections.Generic;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Mapper
{
    internal interface IMapper
    {
        ICoreContract GetContract(int id);
        IEnumerable<ICoreContract> GetContracts();
        ICoreContract CreateContract();
        void UpdateContract(ICoreContract contract);
        void DeleteContract(int id);
    }
}