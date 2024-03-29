﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Mapper.Sql
{
    internal abstract class SqlMapper : IMapper
    {
        protected const string ScriptsSqlPath = @"SQL";

        protected abstract int GetCommandTimeout();
        public abstract DbConnection CreateConnection(string connectionString);
        public abstract DbCommand CreateCommang(string commandText, DbConnection connection);
        public abstract DbParameter CreateParameter(string paramName, object value);

        private readonly Dictionary<string, Dictionary<string, string>> _scripts = new Dictionary<string, Dictionary<string, string>>();

        /// <summary> Возвращает скрипт из ресурсов. </summary>
        /// <param name="section"> Секция в которой расположен скрипт. </param>
        /// <param name="path"> Положение скрипта. </param>
        /// <param name="name"> Наименование скрипта. </param>
        /// <returns> Загруженный скрипт. </returns>
        /// <exception> Указанный скрипт не найден в ресурсах. </exception>
        public string GetScript(string section, string path, string name)
        {
            if (string.IsNullOrEmpty(section))
                throw new ArgumentNullException(nameof(section));

            if (string.IsNullOrEmpty(section))
                throw new ArgumentNullException(nameof(path));

            if (string.IsNullOrEmpty(section))
                throw new ArgumentNullException(nameof(name));

            if (!_scripts.ContainsKey(section))
                _scripts.Add(section, new Dictionary<string, string>());

            var dataSection = _scripts[section];

            string retValue;
            if (!dataSection.ContainsKey(name))
            {
                retValue = ErhmannExtensions.GetTextResource(Assembly.GetExecutingAssembly(), $@"{section}\{path}\{name}.sql");

                if (string.IsNullOrEmpty(retValue))
                    throw new Exception($"Текст запроса {name} не загружен.");

                dataSection.Add(name, retValue);
            }
            else
                retValue = dataSection[name];

            return retValue;
        }

        public abstract ICoreContract GetContract(int id);
        public abstract IEnumerable<ICoreContract> GetContracts();
        public abstract ICoreContract CreateContract(string name, DateTime startDate, DateTime endDate);
        public abstract ICoreContract UpdateContract(ICoreContract contract);
        public abstract bool DeleteContract(ICoreContract contract);
        public abstract ICoreArticleGroup GetArticleGroup(int id);
        public abstract IEnumerable<ICoreArticleGroup> GetArticleGroups(ICoreContract contract);
        public abstract ICoreArticleGroup CreateArticleGroup(ICoreContract contract, string name);
        public abstract ICoreArticleGroup UpdateArticleGroup(ICoreArticleGroup articleGroup);
        public abstract bool DeleteArticleGroup(ICoreArticleGroup articleGroup);
        public abstract ICoreConditionType GetConditionType(int id);
        public abstract IEnumerable<ICoreConditionType> GetConditionTypes(ICoreArticleGroup articleGroup);
        public abstract ICoreConditionType CreateConditionType(ICoreArticleGroup articleGroup, string name, int retro, int retroDistr, int rku, int rkuDistr);
        public abstract ICoreConditionType UpdateConditionType(ICoreConditionType conditionType);
        public abstract bool DeleteConditionType(ICoreConditionType conditionType);
    }
}