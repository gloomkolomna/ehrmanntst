using System;
using System.Collections.Generic;
using Ehrmann.Core;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann
{
    internal static class Helpers
    {
        public static IEhrmannCore GetEhrmannCore(SourceType sourceType, string connectionString)
        {
            return EhrmannCore.Create(sourceType, connectionString);
        }
        
        public static IEnumerable<ICoreContract> GetContracts(IEhrmannCore ehrmannCore)
        {
            return ehrmannCore.GetContracts();
        }

        public static ICoreContract CreateContract(IEhrmannCore ehrmannCore, string name, DateTime startDate, DateTime endDate)
        {
            return ehrmannCore.CreateContract(name, startDate, endDate);
        }

        public static ICoreContract UpdateContract(IEhrmannCore ehrmannCore, ICoreContract coreContract)
        {
            return ehrmannCore.UpdateContract(coreContract);
        }

        public static bool DeleteContract(IEhrmannCore ehrmannCore, ICoreContract coreContract)
        {
            return ehrmannCore.DeleteContract(coreContract);
        }
    }
}