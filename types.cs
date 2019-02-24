using System;
using System.Reflection;
using System.Collections.Generic;

namespace Practice
{
    class Program
    {
        static void Main()
        {
            //Пример информации о сборке взят из Рихтера
            string dataAssembly = "System.Data, version=4.0.0.0, " +
                "culture=netral, PublicKeyToken=b77a5c561934e089";
              ShowPublicTypes(dataAssembly);

            Type openType = typeof(Dictionary<,>);
            Type closedType = openType
                .MakeGenericType(new Type[] { typeof(string), typeof(int) });
            object obj = Activator.CreateInstance(closedType);
        }

        public static void ShowPublicTypes(string assemID)
        {
            Assembly a = Assembly.Load(assemID);
            foreach (Type e in a.ExportedTypes)
            {
                Console.WriteLine(e.FullName);
            }
        }

        private static bool AreObjectTheSameType(object obj1, object obj2)
        {
            return obj1.GetType() == obj2.GetType();
        }


    }
}
