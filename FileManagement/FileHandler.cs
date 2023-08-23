using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace snake.FileManagement
{
    public abstract class FileHandler
    {
        protected readonly string _filePath;

        public FileHandler(string filePath)
        {
            _filePath = filePath;
        }

        protected void CreateFileIfNotExists()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose();  // Create and close the file immediately.
            }
        }

        protected void WriteToFile(string content)
        {
            File.WriteAllText(_filePath, content);
        }

        protected string ReadFromFile()
        {
            return File.ReadAllText(_filePath);
        }

        protected void DeleteFile()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}