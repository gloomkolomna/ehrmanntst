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
        public IEnumerable<ICoreConditionType> GetConditionTypes(int articleGroupId)
        {
            try
            {
                var conditionTypes = new List<ICoreConditionType>();
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ConditionType", "GetConditionTypes");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@ownerId", articleGroupId));
                        var reader = command.ExecuteReader();
                        try
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var conditionType = GetCoreConditionType(reader);
                                    conditionTypes.Add(conditionType);
                                }
                            }
                        }
                        finally
                        {
                            reader?.Close();
                        }
                    }
                }
                return conditionTypes;
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