using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class TestCollections
    {
        private List<Person> Persons { get; set; }
        private List<string> StringList { get; set; }
        private Dictionary<Person, Employee> TestDictionary1 { get; set; }
        private Dictionary<string, Employee> TestDictionary2 { get; set; }

        public TestCollections(int numberOfEmployees) 
        {
            Persons = new List<Person>();
            StringList = new List<string>();
            TestDictionary1 = new Dictionary<Person, Employee>();
            TestDictionary2 = new Dictionary<string, Employee>();
            
            for(int i = 0; i < numberOfEmployees; i++)
            {
                Employee employee = CreateEmployee(i);
                Persons.Add(employee.PersonData);
                StringList.Add(employee.ToString());
                TestDictionary1.Add(employee.PersonData, employee);
                TestDictionary2.Add(employee.ToString(), employee);
            }
        }
        public static Employee CreateEmployee(int id)
        {
            string name = id.ToString();
            return new Employee(new Person(name, name, new DateTime()), "Beginner", TimeWork.Free, 100);
        }
        
        public TimeSpan SearchPerson(Person person)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool result = Persons.Contains(person);
            stopwatch.Stop();
            Console.WriteLine("Does list contains person: " + result);
            return stopwatch.Elapsed;
        }
        public TimeSpan SearchString(string str)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool result = StringList.Contains(str);
            stopwatch.Stop();
            Console.WriteLine("Does list contains string: " + result);
            return stopwatch.Elapsed;
        }
        public TimeSpan SearchByKeyInDictionary1(Person person)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool result = TestDictionary1.ContainsKey(person);
            stopwatch.Stop();
            Console.WriteLine("Does dictionary1 contains key person: " + result);
            return stopwatch.Elapsed;
        }
        public TimeSpan SearchByKeyInDictionary2(string str)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool result = TestDictionary2.ContainsKey(str);
            stopwatch.Stop();
            Console.WriteLine("Does dictionary2 contains key string: " + result);
            return stopwatch.Elapsed;
        }
        public TimeSpan SearchByValueInDictionary1(Employee employee)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool result = TestDictionary1.ContainsValue(employee);
            stopwatch.Stop();
            Console.WriteLine("Does dictionary1 contains value employee: " + result);
            return stopwatch.Elapsed;
        }
        public TimeSpan SearchByValueInDictionary2(Employee employee)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool result = TestDictionary2.ContainsValue(employee);
            stopwatch.Stop();
            Console.WriteLine("Does dictionary2 contains value employee: " + result);
            return stopwatch.Elapsed;
        }
    }
}
