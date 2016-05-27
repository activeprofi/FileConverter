using System;
using SFile = System.IO.File;

namespace FormatConverter.Convertion.Utils
{
    public sealed class File
    {
        private readonly string _path;        

        public File(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("File path is empty", path);
            }

            _path = path;
        }        

        public string Content() =>
            SFile.ReadAllText(_path);

        public void CopyTo(string toPath) =>
            SFile.Copy(_path, toPath);

        public static File WriteFile(string newPath, string contents)
        {
            SFile.WriteAllText(newPath, contents);
            return new File(newPath);
        }
    }
}
