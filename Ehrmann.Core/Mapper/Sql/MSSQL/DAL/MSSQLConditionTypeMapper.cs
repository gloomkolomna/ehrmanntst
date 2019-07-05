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
        public override ICoreConditionType GetConditionType(int id)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ConditionType", "GetConditionType");
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
                                    var conditionType = GetCoreConditionType(reader);
                                    return conditionType;
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

        public override IEnumerable<ICoreConditionType> GetConditionTypes(ICoreArticleGroup articleGroup)
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
                        command.Parameters.Add(CreateParameter("@ownerId", articleGroup.Id));
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

        public override ICoreConditionType CreateConditionType(ICoreArticleGroup articleGroup, string name, int retro, int retroDistr, int rku, int rkuDistr)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ConditionType", "CreateConditionType");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@name", name));
                        command.Parameters.Add(CreateParameter("@retro", retro));
                        command.Parameters.Add(CreateParameter("@retroDistr", retroDistr));
                        command.Parameters.Add(CreateParameter("@rku", rku));
                        command.Parameters.Add(CreateParameter("@rkuDistr", rkuDistr));
                        command.Parameters.Add(CreateParameter("@ownerId", articleGroup.Id));
                        var id = (int)command.ExecuteScalar();

                        return new CoreConditionTypeImpl()
                        {
                            Id = id,
                            Name = name,
                            Retro = retro,
                            RetroDistr = retroDistr,
                            Rku = rku,
                            RkuDistr = rkuDistr,
                            OwnerId = articleGroup.Id
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

        public override ICoreConditionType UpdateConditionType(ICoreConditionType conditionType)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ConditionType", "UpdateConditionType");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@id", conditionType.Id));
                        command.Parameters.Add(CreateParameter("@name", conditionType.Name));
                        command.Parameters.Add(CreateParameter("@retro", conditionType.Retro));
                        command.Parameters.Add(CreateParameter("@retroDistr", conditionType.RetroDistr));
                        command.Parameters.Add(CreateParameter("@rku", conditionType.Rku));
                        command.Parameters.Add(CreateParameter("@rkuDistr", conditionType.RkuDistr));
                        command.ExecuteScalar();

                        return conditionType;
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

        public override bool DeleteConditionType(ICoreConditionType conditionType)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ConditionType", "DeleteConditionType");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@id", conditionType.Id));
                        command.ExecuteNonQuery();
                        var result = command.ExecuteNonQuery();

                        return result == 0;
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
    }
}