using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lecture7
{
    public class BinarySerialization
    {
        private const string FileToSaveSerializedObjects = "Hogwarts.school";

        [Serializable] // All objects need to be covered with this.
        public class EntityToSerialize
        {
            public string Name { get; set; }

            public string SecondName { get; set; }

            public InnerObject Inner { get; set; }

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(SecondName)}: {SecondName}"; // nameof 
            }
        }

        [Serializable]
        public class InnerObject
        {
            public string MiddleName { get; set; }
        }

        public void SerializeEntity(EntityToSerialize entity)
        {
            var formatter = new BinaryFormatter();
            using var fileToSaveIn = new FileStream(FileToSaveSerializedObjects, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(fileToSaveIn, entity);
        }

        public EntityToSerialize DeserializeEntity()
        {
            var formatter = new BinaryFormatter();
            using var stream = new FileStream(FileToSaveSerializedObjects, FileMode.Open, FileAccess.Read, FileShare.Read);
            return (EntityToSerialize)formatter.Deserialize(stream);
        }
    }
}