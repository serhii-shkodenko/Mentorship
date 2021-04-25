namespace Lecture4.Exceptions
{
    public class Invoker
    {
        private readonly TextReader _textReader;

        public Invoker()
        {
            _textReader = new TextReader();
        }

        public void InvokeReadingFor(string path)
        {
            _textReader.ReadFile(path);
        }
    }
}