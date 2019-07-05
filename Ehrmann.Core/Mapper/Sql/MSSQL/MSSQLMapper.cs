using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Ehrmann.Core.Models.Impls;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Mapper.Sql.MSSQL
{
    internal partial class MSSQLMapper : SqlMapper
    {
        private const string ScriptsSection = @"MSSQL\DAL\Scripts";
        private readonly string _connection;

        public MSSQLMapper(string connection)
        {
            _connection = connection;
        }
        
        protected override int GetCommandTimeout()
        {
            return 120;
        }

        public override DbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public override DbCommand CreateCommang(string commandText, DbConnection connection)
        {
            return new SqlCommand(commandText, (SqlConnection)connection);
        }

        public override DbParameter CreateParameter(string paramName, object value)
        {
            return new SqlParameter() { ParameterName = paramName, Value = value };
        }

        protected ICoreContract GetCoreContract(IDataRecord reader)
        {
            try
            {
                var contract = new CoreContractImpl()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    EndDate = DateTime.Parse(reader["EndDate"].ToString()),
                    StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                    Name = reader["Name"].ToString()
                };
                contract.ArticleGroups = GetArticleGroups(contract.Id);

                return contract;
            }
            catch (Exception ex)
            {
                // тут хорошо бы задействовать логгер, например, NLog
                Trace.TraceError(ex.Message);
                throw;
            }
        }

        protected ICoreArticleGroup GetArticleGroup(IDataRecord reader)
        {
            try
            {
                var articleGroup = new CoreArticleGroupImpl()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    OwnerId = int.Parse(reader["OwnerId"].ToString()),
                    Name = reader["Name"].ToString()
                };
                articleGroup.ConditionTypes = GetConditionTypes(articleGroup.Id);

                return articleGroup;
            }
            catch (Exception ex)
            {
                // тут хорошо бы задействовать логгер, например, NLog
                Trace.TraceError(ex.Message);
                throw;
            }
        }

        protected ICoreConditionType GetCoreConditionType(IDataRecord reader)
        {
            try
            {
                var conditionType = new CoreConditionTypeImpl()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    OwnerId = int.Parse(reader["OwnerId"].ToString()),
                    Name = reader["Name"].ToString(),
                    Retro = int.Parse(reader["Retro"].ToString()),
                    RetroDistr = int.Parse(reader["RetroDistr"].ToString()),
                    Rku = int.Parse(reader["Rku"].ToString()),
                    RkuDistr = int.Parse(reader["RkuDistr"].ToString())
                };

                return conditionType;
            }
            catch (Exception ex)
            {
                // тут хорошо бы задействовать логгер, например, NLog
                Trace.TraceError(ex.Message);
                throw;
            }
        }
    }
}