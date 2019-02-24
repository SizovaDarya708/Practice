using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Practice
{
    class Program
    {
        static void Main()
        {
            var objectGraph = new List<string> { "jojo", "hehe", "wenk wenk", "woof woof"};
            Stream stream = SerializeToMemory(objectGraph);

            stream.Position = 0;
            objectGraph = null;

            objectGraph = (List<string>) DeserializeFromMemory(stream);
            foreach (var e in objectGraph)
            {
                Console.WriteLine(e);
            }

        
        }

        private static object DeserializeFromMemory(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        private static MemoryStream SerializeToMemory(object objectGraph)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objectGraph);
            return stream;
        }


////////////////////////////////////////////////////////////

        [Serializable]
        public class Bird
        {
            public string Name;
            public int Weight;
            [NonSerialized]
            public string BirdsSecret;
            public enum SpecialSigns
            {
                cute,
                pretty,
                cool
            };
            public Bird(string name, int weight)
            {
                name = Name;
                weight = Weight;
            }       
        }
        public interface IFormatter
        {
            SerializationBinder Binder { get; set; }
            StreamingContext Context { get; set; }
            ISurrogateSelector SurrogateSelector { get; set; }
            object Deserialize(Stream serializationStream);
            void Serialize(Stream serializationStream, object graph);
        }

    }
}
