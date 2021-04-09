using System;

namespace Lecture1
{
    public class TryCanPattern
    {
        public bool TryGenerate(int valueForCondition, out string result)
        {
            if (valueForCondition == 1)
            {
                result = "Some string";
                return true;
            }

            result = default;
            return false;
        }

        public void SomeMethod()
        {
            if(TryGenerate(1, out var result ))
            {
                Console.WriteLine(result);
            }

            var input = new Random().Next();


        }
    }
}