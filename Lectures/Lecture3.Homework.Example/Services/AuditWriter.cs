using Lecture3.Homework.Example.Models;
using System.IO;

namespace Lecture3.Homework.Example.Services
{
    public class AuditWriter
    {
        private readonly StreamWriter streamWriter;

        public bool Write(IAuditable auditable)
        {
            var content = auditable.GenerateContent();

            streamWriter.WriteLine(content);
            return true;
        }
    }
}