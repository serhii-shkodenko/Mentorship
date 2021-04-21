using System;

namespace Lecture3.Oo
{
    internal interface IFlyable
    {
        public static string Name { get; set; }

        public void Fly()
        {
            Console.WriteLine("I can fly!");
        }

        public void Action()
        {

        }
    }
}