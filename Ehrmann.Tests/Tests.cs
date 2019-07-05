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

        #region Contract Tests

        [Test(Description = "0ba8cd8a-7039-4a69-abda-b536ece15cf5"), Order(1)]
        public void CreateContractTest()
        {
            var contract = _ehrmannCore.CreateContract("102000.604579-ИП Гапеев/Ромашка (Согласовано)", DateTime.Now, DateTime.MaxValue);
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
        public void UpdateContractTest()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");

            var contract = contracts.FirstOrDefault();
            if (contract != null)
            {
                contract.EndDate = DateTime.Now;
                
                var result = _ehrmannCore.UpdateContract(contract);
                Assert.IsNotNull(result, $"Не удалось обновить контракт {contract.Id}");
            }
        }

        [Test(Description = "fc6ae615-8d01-4fd4-91d1-7d612be2eee3"), Order(5)]
        public void DeleteContractTest()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");

            var contract = contracts.FirstOrDefault();
            if (contract != null)
            {
                var result = _ehrmannCore.DeleteContract(contract);
                Assert.IsTrue(result, $"Не удалось удалить контракт {contract.Id}");
            }
        }

        #endregion

        #region ArticleGroup Tests

        [Test(Description = "49b1a155-0119-483b-a528-09cadffd5c2d"), Order(6)]
        public void CreateArticleGroupTest()
        {
            var contract = _ehrmannCore.CreateContract("Contract", DateTime.Now, DateTime.MaxValue);
            Assert.IsNotNull(contract, "Не удалось создать контракт");
            var articleGroup = _ehrmannCore.CreateArticleGroup(contract, "Article");
            Assert.IsNotNull(articleGroup, "Не удалось создать артикульную группу");
        }

        [Test(Description = "af1bc6b4-15e5-43ec-bdd6-7795122c0a7d"), Order(7)]
        public void GetAricleGroupsTest()
        {
            var contract = _ehrmannCore.GetContract(1);
            Assert.IsNotNull(contract, "Не удалось получить контракт");
            var articleGroups = _ehrmannCore.GetArticleGroups(contract);
            Assert.IsNotEmpty(articleGroups, "Не удалось получить коллекцию артикульных групп контракта");
        }

        [Test(Description = "46a4a299-1e8c-42d5-8fc7-d71555b31ce4"), Order(8)]
        public void GetAricleGroupTest()
        {
            var contract = _ehrmannCore.GetContract(1);
            Assert.IsNotNull(contract, "Не удалось получить контракт");
            var articleGroup = _ehrmannCore.GetArticleGroup(1);
            Assert.IsNotNull(articleGroup, "Не удалось получить артикульную группу");
        }

        [Test(Description = "118cf616-ae32-48f9-b7d2-a191410949b6"), Order(9)]
        public void UpdateAricleGroupTest()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");

            var contract = contracts.FirstOrDefault();
            if (contract != null)
            {
                var articleGroup = contract.ArticleGroups.FirstOrDefault();
                if (articleGroup != null)
                {
                    articleGroup.Name = "ololo";
                    var result = _ehrmannCore.UpdateArticleGroup(articleGroup);
                    Assert.IsNotNull(result, $"Не удалось обновить артикульную группу {articleGroup.Id}");
                }
            }
        }

        [Test(Description = "6a7c8ed5-1e31-4a06-964b-7f9342225eb0"), Order(10)]
        public void DeleteAricleGroupTest()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");

            var contract = contracts.FirstOrDefault();
            if (contract != null)
            {
                var articleGroup = contract.ArticleGroups.FirstOrDefault();
                if (articleGroup != null)
                {
                    var result = _ehrmannCore.DeleteArticleGroup(articleGroup);
                    Assert.IsTrue(result, $"Не удалось удалить артикульную группу {articleGroup.Id}");
                }
            }
        }

        #endregion

        #region ConditionType Tests

        [Test(Description = "b5c5d2b4-18ce-4f2d-be4b-33162a68f72f"), Order(11)]
        public void CreateConditionTypeTest()
        {
            var contract = _ehrmannCore.CreateContract("102000.604579-ИП Гапеев/Ромашка (Согласовано)", DateTime.Now, DateTime.MaxValue);
            Assert.IsNotNull(contract, "Не удалось создать контракт");
            var articleGroup = _ehrmannCore.CreateArticleGroup(contract, "EPICA 130г.");
            Assert.IsNotNull(articleGroup, "Не удалось создать артикульную группу");
            var conditionType = _ehrmannCore.CreateConditionType(articleGroup, "Объем", 10, 30, 10, 12);
            Assert.IsNotNull(conditionType, "Не удалось создать вид условия");
        }

        [Test(Description = "4deabf37-a05d-4f18-90f2-6589a7bea45a"), Order(12)]
        public void GetConditionTypesTest()
        {
            var contract = _ehrmannCore.GetContract(1);
            Assert.IsNotNull(contract, "Не удалось получить контракт");
            var articleGroup = contract.ArticleGroups.FirstOrDefault();
            Assert.IsNotNull(articleGroup, "Не удалось получить артикульную группу контракта");
            var conditionTypes = _ehrmannCore.GetConditionTypes(articleGroup);
            Assert.IsNotEmpty(conditionTypes, "Не удалось получить коллекцию видов условий");
        }

        [Test(Description = "80c1d1d2-2fd1-4f80-acc6-11e2e4d331f2"), Order(13)]
        public void GetConditionTypeTest()
        {
            var contract = _ehrmannCore.GetContract(1);
            Assert.IsNotNull(contract, "Не удалось получить контракт");
            var articleGroup = _ehrmannCore.GetArticleGroup(1);
            Assert.IsNotNull(articleGroup, "Не удалось получить артикульную группу");
            var conditionType = _ehrmannCore.GetConditionType(1);
            Assert.IsNotNull(conditionType, "Не удалось получить вид условия");
        }

        [Test(Description = "04d72bba-c8d6-408e-976c-931adb90f717"), Order(14)]
        public void UpdateConditionTypeTest()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");

            var contract = contracts.FirstOrDefault();
            if (contract != null)
            {
                var articleGroup = contract.ArticleGroups.FirstOrDefault();
                if (articleGroup != null)
                {
                    var conditionType = articleGroup.ConditionTypes.FirstOrDefault();
                    if (conditionType != null)
                    {
                        conditionType.Retro = 100;
                        conditionType.Rku = 1000;

                        var result = _ehrmannCore.UpdateConditionType(conditionType);
                        Assert.IsNotNull(result, $"Не удалось обновить вид условия {conditionType.Id}");
                    }
                }
            }
        }

        [Test(Description = "2ba0d76a-3eac-490f-a1aa-9920556a40a3"), Order(15)]
        public void DeleteConditionTypeTest()
        {
            var contracts = _ehrmannCore.GetContracts();
            Assert.IsNotEmpty(contracts, "Не удалось получить контракты");

            var contract = contracts.LastOrDefault();
            if (contract != null)
            {
                var articleGroup = contract.ArticleGroups.FirstOrDefault();
                if (articleGroup != null)
                {
                    var conditionType = articleGroup.ConditionTypes.FirstOrDefault();
                    if (conditionType != null)
                    {
                        var result = _ehrmannCore.DeleteConditionType(conditionType);
                        Assert.IsTrue(result, $"Не удалось удалить вид условия {conditionType.Id}");
                    }
                }
            }
        }

        #endregion
    }
}
