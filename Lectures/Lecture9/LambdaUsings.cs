using System;

namespace Lecture9
{
    public class LambdaUsings
    {
        public string GetExample()
        {
            return "example";
        }

        public string GetExampleLambda() => "example";

        public string ExampleProperty => "example";

        // Switch expression

        public string GetTypeName(Type type) =>

             type switch
             {
                 Type => "string",
                 _ => throw new NotImplementedException(),
             };
        
            
    }
}