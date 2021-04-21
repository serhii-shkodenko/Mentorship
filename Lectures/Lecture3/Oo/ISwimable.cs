using System;

namespace Lecture3.Oo
{
    internal interface ISwimable
    {
        public static string Name { get; set; }

        public void Swim()
        {
            Console.WriteLine("I can swim!");
        }

        public void Action()
        {

        }
    }
}