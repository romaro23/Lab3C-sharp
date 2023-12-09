using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
#pragma warning disable SYSLIB0011
namespace Lab3
{
    [Serializable]
    internal class Employee : Person
    {
        private string position;
        private TimeWork work_time;
        private int salary;
        private List<Diploma> diplomas = new List<Diploma>();
        private List<Experience> experiences = new List<Experience>();

        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public TimeWork WorkTime
        {
            get { return work_time; }
            set { work_time = value; }
        }
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value <= 0 || value > 2000)
                {
                    throw new ArgumentOutOfRangeException("The value must be from 1 to 2000");
                }
                else
                {
                    salary = value;
                }
            }
        }
        public Person PersonData
        {
            get { return new Person(this.Name, this.Surname, this.Date); }
            set
            {
                this.Name = value.Name;
                this.Surname = value.Surname;
                this.Date = value.Date;
            }
        }
        public List<Diploma> Diplomas
        {
            get { return diplomas; }
            set { diplomas = value; }
        }
        public List<Experience> Experiences
        {
            get { return experiences; }
            set { experiences = value; }
        }
        public Diploma lastDiploma
        {
            get
            {
                if (Diplomas.Count == 0)
                {
                    return null;
                }
                else
                {
                    Diploma latestDiploma = Diplomas[0];
                    for (int i = 1; i < Diplomas.Count; i++)
                    {
                        if (Diplomas[i].Date > latestDiploma.Date)
                        {
                            latestDiploma = Diplomas[i];
                        }
                    }

                    return latestDiploma;
                }
            }
        }
        public bool Save(string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    bf.Serialize(fStream, this);
                    fStream.Close();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
        public bool Load(string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using(Stream fStream = File.OpenRead(filename))
                {
                    Employee temp = (Employee)bf.Deserialize(fStream);
                    name = temp.Name;
                    surname = temp.Surname;
                    dateOfBirth = temp.dateOfBirth;
                    position = temp.position;
                    work_time = temp.work_time;
                    salary = temp.salary;
                    diplomas = temp.diplomas;
                    experiences = temp.experiences;
                    fStream.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Could not load {filename}. {ex.Message}");
                return false;
            }
        }
        internal static bool Save(string filename, Employee obj)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    bf.Serialize(fStream, obj);
                    fStream.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        internal static bool Load(string filename, Employee obj)
      
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream fStream = File.OpenRead(filename))
                {
                    obj = (Employee)bf.Deserialize(fStream);
                    fStream.Close();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not load {filename}. {ex.Message}");
                return false;
            }
        }
        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine("Enter information about a diploma: name, qualification, date of issue(dd.mm.yyyy). Use ';' or ',' as separators");
                string input = Console.ReadLine();
                char[] separators = { ',', ';' };
                string[] tokens = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 3)
                {
                    throw new FormatException("Invalid input format");
                }
                Diplomas.Add(new Diploma(tokens[0], tokens[1], DateTime.Parse(tokens[2])));
                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return false;
            }
        }
        public Employee DeepCopy()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                bf.Serialize(stream, this);
                stream.Position = 0;
                return (Employee)bf.Deserialize(stream);
            }

        }
        public void AddDiplomas(params Diploma[] new_diplomas)
        {
            for (int i = 0; i < new_diplomas.Length; i++)
            {
                Diplomas.Add(new_diplomas[i]);
            }

        }
        public Employee(Person person, string position, TimeWork work_time, int salary)
            : base(person.Name, person.Surname, person.Date)
        {
            Position = position;
            WorkTime = work_time;
            Salary = salary;
        }
        public Employee()
        {
            Position = "Beginner";
            WorkTime = new TimeWork();
            Salary = 1;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, DateOfBirth: {Date}, Position: {Position}, WorkTime: {WorkTime}, Salary: {Salary}, Diplomas: {string.Join("; ", Diplomas)}, Experience: {string.Join("; ", Experiences)}";
        }
        public override string ToShortString()
        {
            return $"Name: {Name}, Surname: {Surname}, DateOfBirth: {Date}, Position: {Position}, WorkTime: {WorkTime}, Salary: {Salary}, NumberOfDiplomas {Diplomas.Count}";
        }
}
}
