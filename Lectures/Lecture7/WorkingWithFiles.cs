using System;
using System.IO;
using System.Text;

namespace Lecture7
{
    public class WorkingWithFiles
    {
        public void CreateFile(string fileName)
        {
            // CurrentLocation to find out.
            // AppDomain.CurrentDomain.BaseDirectory,
            // Environment.CurrentDirectory
            // System.Reflection.Assembly.GetExecutingAssembly().Location,

            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                fileName,
            };

            using var file = new FileStream(Path.Combine(pathParts), FileMode.Create); // CreateNew vs Create
            using var stream = new StreamWriter(file, Encoding.UTF8);
        }

        public void Append(string fileName, string infoToWrite)
        {
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                fileName
            };

            using var file = new FileStream(Path.Combine(pathParts), FileMode.Append);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.AutoFlush = true;
            stream.Write(infoToWrite);
        }

        public void AppendLine(string fileName, string infoToWrite)
        {
            var pathParts = new[]
            {
                AppDomain.CurrentDomain.BaseDirectory,
                fileName
            };

            var filePath = Path.Combine(pathParts);

            if (File.Exists(filePath))
            {
                return;
            } // Directory.Exists for deirectories.

            using var file = new FileStream(filePath, FileMode.Append);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.AutoFlush = true;
            stream.WriteLine(infoToWrite);
        }
    }
}