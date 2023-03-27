using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{

    public class Person
    {
        public long Id { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  int Age { get; set; }
        public  double Salary { get; set; }

        public Person()
        {
        }

        public Person(string firstName, string lastName, int age, double salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary= salary; 
        }

        public List<string> ReadPerson(string[] args)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write(args[i] + ": ");
                result.Add(Console.ReadLine());
            }
            return result;
        }
    }
}

