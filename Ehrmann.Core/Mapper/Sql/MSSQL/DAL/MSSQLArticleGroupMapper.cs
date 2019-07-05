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
        public override ICoreArticleGroup GetArticleGroup(int id)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ArticleGroup", "GetArticleGroup");
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
                                    var contract = GetCoreArticleGroup(reader);
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

        public override IEnumerable<ICoreArticleGroup> GetArticleGroups(ICoreContract contract)
        {
            try
            {
                var articleGroups = new List<ICoreArticleGroup>();
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ArticleGroup", "GetArticleGroups");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@ownerId", contract.Id));
                        var reader = command.ExecuteReader();
                        try
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var articleGroup = GetCoreArticleGroup(reader);

                                    articleGroups.Add(articleGroup);
                                }
                            }
                        }
                        finally
                        {
                            reader?.Close();
                        }
                    }
                }
                return articleGroups;
            }
            catch (Exception ex)
            {
                // тут хорошо бы задействовать логгер, например, NLog
                Trace.TraceError(ex.Message);
                throw;
            }
        }
        
        public override ICoreArticleGroup CreateArticleGroup(ICoreContract contract, string name)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ArticleGroup", "CreateArticleGroup");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@name", name));
                        command.Parameters.Add(CreateParameter("@ownerId", contract.Id));
                        var id = (int)command.ExecuteScalar();

                        return new CoreArticleGroupImpl()
                        {
                            Id = id,
                            Name = name,
                            OwnerId = contract.Id
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

        public override ICoreArticleGroup UpdateArticleGroup(ICoreArticleGroup articleGroup)
        {
            try
            {
                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ArticleGroup", "UpdateArticleGroup");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@id", articleGroup.Id));
                        command.Parameters.Add(CreateParameter("@name", articleGroup.Name));
                        command.ExecuteScalar();

                        return articleGroup;
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

        public override bool DeleteArticleGroup(ICoreArticleGroup articleGroup)
        {
            try
            {
                foreach (var conditionType in articleGroup.ConditionTypes)
                {
                    var deleteConditionType = DeleteConditionType(conditionType);
                    if (!deleteConditionType)
                        return false;
                }

                using (var connection = CreateConnection(_connection))
                {
                    connection.Open();
                    var commandText = GetScript(ScriptsSection, ScriptsSqlPath + @"\ArticleGroup", "DeleteArticleGroup");
                    using (var command = CreateCommang(commandText, connection))
                    {
                        command.CommandTimeout = GetCommandTimeout();
                        command.Parameters.Add(CreateParameter("@id", articleGroup.Id));
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