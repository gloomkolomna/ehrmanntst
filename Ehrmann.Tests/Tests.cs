using System;
using System.Linq;
using Ehrmann.Core;
using NUnit.Framework;

namespace Ehrmann.Tests
{
    [TestFixture]
    public class Tests
    {
        private IEhrmannCore _ehrmannCore;
        private const string ConnectionString = @"Server=BELOVOLOV-E\SQLEXPRESS;Database=Err;Integrated Security=SSPI;Persist Security Info=False;";
        
        [SetUp]
        public void Init()
        {
            _ehrmannCore = EhrmannCore.Create(SourceType.MSSQL, ConnectionString);
        }

        [Test(Description = "0ba8cd8a-7039-4a69-abda-b536ece15cf5"), Order(1)]
        public void CreateContractTest()
        {
            var contract = _ehrmannCore.CreateContract("Contract1", DateTime.Now, DateTime.MaxValue);
            Assert.IsNotNull(contract, "Не удалось создать контракт");
        }

        [Test(Description = "4efa0733-7ee8-4463-a15b-891ef0818f7a"), Order(2)]
        public void GetContractsTest()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");
        }

        [Test(Description = "c2059942-ea39-4d58-8a41-db4f13814253"), Order(3)]
        public void GetContractTest()
        {
            var contract = _ehrmannCore.GetContract(1);
            Assert.IsNotNull(contract, "Не удалось получить контракт");
        }

        [Test(Description = "0d8e0492-e615-4149-96c7-ff9f29c6c2ec"), Order(4)]
        public void UpdateContract()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");

            var contract = contracts.LastOrDefault();
            if (contract != null)
            {
                contract.EndDate = DateTime.Now;
                
                var result = _ehrmannCore.UpdateContract(contract);
                Assert.IsNotNull(result, $"Не удалось обновить контракт {contract.Id}");
            }
        }

        [Test(Description = "fc6ae615-8d01-4fd4-91d1-7d612be2eee3"), Order(5)]
        public void DeleteContract()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");

            var contract = contracts.LastOrDefault();
            if (contract != null)
            {
                var result = _ehrmannCore.DeleteContract(contract.Id);
                Assert.IsTrue(result, $"Не удалось удалить контракт {contract.Id}");
            }
        }
    }
}
