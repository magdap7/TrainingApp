using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrainingApp
{
    public class GenericClass<T> 
    {
        public GenericClass() { }
        public GenericClass(string name) { }

        public void WriteObjectToFile<T>(T obj)
        {
            var jsonObj = JsonSerializer.Serialize<T>(obj);
            using (var writer = File.AppendText(obj.GetType().Name + ".txt"))
            {
                writer.WriteLine(jsonObj);
            }
        }

        public List<T> ReadObjectsFromFile<T>(string file)
        {
            List<T> objList = new List<T>();
            using (var reader = File.OpenText(file))
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    objList.Add(JsonSerializer.Deserialize<T>(line));
                    line = reader.ReadLine();
                }
            }
            return objList;
        }

        public List<string> ReadObjectFromConsole<T>(T obj)
        {
            //string[] keyWords = new[] { "System.String", "Int32", "Double", "Single" };
            List<string> result = new List<string>();
            var nameOfType = obj.GetType().Name;
            var properties = obj.GetType().GetProperties().ToArray();
            Console.WriteLine("Type properties for object from class: " + nameOfType);
            for (int i = 0; i < properties.Length - 1; i++)
            {
                var propertyName = properties[i].ToString().Split(" ");
                Console.Write(propertyName[1] + ": ");
                var line = Console.ReadLine();
                bool condition0 = (line != "");
                bool condition1 = propertyName[0].Contains("Int32") && int.TryParse(line, out int intValue);
                bool condition2 = propertyName[0].Contains("Double") && double.TryParse(line, out double doubleValue);
                bool condition3 = propertyName[0].Contains("Single") && float.TryParse(line, out float floatValue);
                bool condition4 = propertyName[0].Contains("String") && !int.TryParse(line, out int numValue);
                if (condition0 && (condition1 || condition2 || condition3 || condition4))
                    result.Add(line);
                else
                    result.Add("0");
            }
            return result;
        }
    }
}
