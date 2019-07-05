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
        bool DeleteContract(int id);
    }
}