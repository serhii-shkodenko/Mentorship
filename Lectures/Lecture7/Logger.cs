using System.IO;

namespace Lecture7
{
    public class Logger
    {
        private const string FileToSaveInfo = "client.output";

        public void SaveIntoFile(string content)
        {
            using var writer = new StreamWriter(FileToSaveInfo);
            writer.Write(content);
        }
    }
}