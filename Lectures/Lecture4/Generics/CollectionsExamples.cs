namespace Lecture4.Generics
{
    public class CollectionsExamples
    {
        public bool Add(int value)
        {
            return true;
        }

        public class CustomType
        {
        }

        public bool Add(CustomType customType)
        {
            return true;
        }

        public bool Add(object obj)
        {
            return true;
        }
    }
}