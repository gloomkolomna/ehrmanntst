using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ehrmann.Core
{
    /// <summary> Содержит набор расширений для сборок. </summary>
    public static class ErhmannExtensions
    {
        #region Методы

        /// <summary> Загружает текстовый файл из ресурсов. </summary>
        /// <param name="assembly"> Сборка, в которой производится поиск ресурса. </param>
        /// <param name="path"> Путь до ресурса. </param>
        /// <returns> Содержимое файла в виде <see> <cref> Byte[] </cref></see> или null. </returns>
        /// <exception cref="ArgumentNullException"> Значение <paramref name="path"/> не задано. </exception>
        public static byte[] GetBinaryResource(this Assembly assembly, string path)
        {
            var stream = GetResourceStream(assembly, path);

            if (stream != null)
            {
                try
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    return bytes;
                }
                catch
                {
                }
            }

            return null;
        }

        /// <summary> Загружает текстовый файл из ресурсов. </summary>
        /// <param name="assembly"> Сборка, в которой производится поиск ресурса. </param>
        /// <param name="path"> Путь до ресурса. </param>
        /// <returns> Содержимое файла в виде <see cref="String"/> или null. </returns>
        /// <exception cref="ArgumentNullException"> Значение <paramref name="path"/> не задано. </exception>
        public static string GetTextResource(this Assembly assembly, string path)
        {
            var stream = GetResourceStream(assembly, path);

            if (stream != null)
            {
                try
                {
                    var reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
                catch (Exception)
                {
                }
            }

            return null;
        }

        /// <summary> Производит поиск ресурса. </summary>
        /// <param name="assembly"> Сборка, в которой производится поиск ресурса. </param>
        /// <param name="path"> Путь до ресурса. </param>
        /// <returns> Поток с найденным ресурсом или null. </returns>
        private static Stream GetResourceStream(Assembly assembly, string path)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (assembly.IsDynamic)
                return null;

            Stream stream = null;

            var resStream = assembly.GetManifestResourceStream($@"{assembly.GetName().Name};component/{path}");

            if (resStream == null)
                resStream = assembly.GetManifestResourceStream($@"{assembly.GetName().Name}.{path.Replace('\\', '.')}");
            else
                stream = resStream;

            if (resStream == null)
            {
                var resPath = assembly.GetManifestResourceNames().FirstOrDefault(
                    entry => entry.EndsWith(path.Replace('\\', '.'), StringComparison.InvariantCultureIgnoreCase));
                if (!string.IsNullOrEmpty(resPath))
                    resStream = assembly.GetManifestResourceStream(resPath);
            }
            else
                stream = resStream;

            if (resStream == null)
            {
                using (var gStream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".g.resources"))
                {
                    if (gStream != null)
                    {
                        using (var reader = new System.Resources.ResourceReader(gStream))
                        {
                            var resEntry =
                                reader.Cast<DictionaryEntry>()
                                    .FirstOrDefault(
                                        entry => entry.Key.ToString().Equals(path.Replace('\\', '/'), StringComparison.InvariantCultureIgnoreCase));
                            stream = resEntry.Value as Stream;
                        }
                    }
                }
            }
            else
                stream = resStream;

            return stream;
        }

        #endregion

    }
}