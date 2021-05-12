using System;
using static Lecture7.BinarySerialization;
using static Lecture7.WorkingWithNetworkStream;

namespace Lecture7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunNetworkStreamExample();

            Console.WriteLine("All is done!");
            Console.ReadLine();
        }

        private static void RunFilesExamples()
        {
            var logFile = "log-today.txt";
            var logger = new WorkingWithFiles();

            logger.CreateFile(logFile);

            logger.Append(logFile, "First.");
            logger.Append(logFile, "Second.");

            logger.AppendLine(logFile, "Third.");
            logger.AppendLine(logFile, "4.");
        }

        private static void RunBinarySerializationExamples()
        {
            var entity = new EntityToSerialize
            {
                Name = "Hermione",
                SecondName = "Granger",
            };

            var writer = new BinarySerialization();

            writer.SerializeEntity(entity);
            Console.WriteLine(writer.DeserializeEntity());
        }

        private static void RunNetworkStreamExample()
        {
            var client = new Client();
            var logger = new Logger();

            var rawResponse = client.GetRawResponseFromServer();
            logger.SaveIntoFile(rawResponse);
        }
    }
}