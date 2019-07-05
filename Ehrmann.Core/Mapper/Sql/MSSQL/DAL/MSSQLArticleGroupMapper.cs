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
        public IEnumerable<ICoreArticleGroup> GetArticleGroups(int contractId)
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
                        command.Parameters.Add(CreateParameter("@ownerId", contractId));
                        var reader = command.ExecuteReader();
                        try
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var articleGroup = GetArticleGroup(reader);

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
    }
}