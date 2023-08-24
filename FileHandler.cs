using System;
using System.IO;


namespace Notepad.WindowsFormsApp
{
    class FileHandler
    {
        public string ReadFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Ścieżka do pliku nie może być pusta lub zawierać tylko białe znaki.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Plik nie istnieje.", filePath);
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }

        public void WriteToFile(string filePath, string content)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Ścieżka do pliku nie może być pusta lub zawierać tylko białe znaki.", nameof(filePath));
            }

            string directoryPath = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directoryPath);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }
    }
}

