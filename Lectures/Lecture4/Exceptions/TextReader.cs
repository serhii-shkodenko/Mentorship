namespace Lecture4.Exceptions
{
    public class TextReader
    {
        public string ReadFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
    }
}