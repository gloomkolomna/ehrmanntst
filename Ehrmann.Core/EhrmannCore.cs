using System;
using Ehrmann.Core.Mapper;
using Ehrmann.Core.Mapper.Access;
using Ehrmann.Core.Mapper.Excel;
using Ehrmann.Core.Mapper.Sql.MSSQL;

namespace Ehrmann.Core
{
    public static class EhrmannCore
    {
        /// <summary>
        /// Фабрика источников данных.
        /// </summary>
        /// <param name="sourceType">Тип источника данных</param>
        /// <param name="connection">Строка подключения к источнику данных. Может быть как строкой подключения к БД, так и путем к файлу.</param>
        /// <returns>Интерфейс работы с источником данных</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEhrmannCore Create(SourceType sourceType, string connection)
        {
            IMapper mapper;
            switch (sourceType)
            {
                case SourceType.MSSQL:
                    mapper = new MSSQLMapper(connection);
                    break;
                case SourceType.Excel:
                    mapper = new ExcelMapper(connection);
                    break;
                case SourceType.Access:
                    mapper = new AccessMapper(connection);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sourceType), sourceType, null);
            }

            return new Erhmann(mapper);
        }
    }
}