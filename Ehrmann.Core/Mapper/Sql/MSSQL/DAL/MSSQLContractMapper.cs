using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Ehrmann.Core.Models.Impls;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Mapper.Sql.MSSQL
{
    internal partial class MSSQLMapper
    {
        public override ICoreContract GetContract(int id)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\Contract", "GetContract");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@id", id));
                        var reader = command.ExecuteReader();
                        try
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var contract = GetCoreContract(reader);
                                    return contract;
                                }
                            }
                        }
                        finally
                        {
                            reader?.Close();
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                // тут хорошо бы задействовать логгер, например, NLog
                Trace.TraceError(ex.Message);
                throw;
            }
        }

        public override IEnumerable<ICoreContract> GetContracts()
        {
            try
            {
                var contracts = new List<ICoreContract>();
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\Contract", "GetContracts");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        var reader = command.ExecuteReader();
                        try
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var contract = GetCoreContract(reader);
                                    contracts.Add(contract);
                                }
                            }
                        }
                        finally
                        {
                            reader?.Close();
                        }
                    }
                }
                return contracts;
            }
            catch (Exception ex)
            {
                // тут хорошо бы задействовать логгер, например, NLog
                Trace.TraceError(ex.Message);
                throw;
            }
        }

        

        public override ICoreContract CreateContract(string name, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\Contract", "CreateContract");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@name", name));
                        command.Parameters.Add(CreateParameter("@startDate", startDate));
                        command.Parameters.Add(CreateParameter("@endDate", endDate));
                        var id = (int) command.ExecuteScalar();

                        return new CoreContractImpl()
                        {
                            Id = id,
                            Name = name,
                            StartDate = startDate,
                            EndDate = endDate,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // тут хорошо бы задействовать логгер, например, NLog
                Trace.TraceError(ex.Message);
                throw;
            }
        }

        public override void UpdateContract(ICoreContract contract)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                // тут хорошо бы задействовать логгер, например, NLog
                Trace.TraceError(ex.Message);
                throw;
            }
        }

        public override void DeleteContract(int id)
        {
            try
            {
                throw new NotImplementedException();
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