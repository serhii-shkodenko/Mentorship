using System;

namespace Lecture8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunJsonSerialization();

            Console.WriteLine("The work is done!");
            Console.ReadLine();
        }

        private static void RunXmlSerializationWithStreams()
        {
            var example = new XmlSerialization();
            var order = example.CollectOrder();
            example.SerializeOrder(order);

            var deserializedObject = example.DeserializeOrder();
            Console.WriteLine(deserializedObject);
        }

        private static void RunXmlSerializationWithIXmlSerializable()
        {
            var example = new XmlSerializationCustomImplementation();
            var order = example.CollectOrder();
            example.SerializeOrder(order);

            var deserializedObject = example.DeserializeOrder();
            Console.WriteLine(deserializedObject);
        }

        private static void RunJsonSerialization()
        {
            var example = new JsonSerialization();
            var order = example.CollectOrder();
            example.SerializeAndSaveOrder(order);

            var deserializedObject = example.DeserializeOrderFromSaved();
            Console.WriteLine(deserializedObject);
        }
    }
}