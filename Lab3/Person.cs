using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    [Serializable]
     class Person
    {
        protected string name;
        protected string surname;
        protected DateTime dateOfBirth;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        public int Year
        {
            get
            {
                return dateOfBirth.Year;
            }
            set
            {
                dateOfBirth = new DateTime(value, dateOfBirth.Month, dateOfBirth.Day);
            }
        }
        public Person()
        {
            Name = "Roman";
            Surname = "Nagorniy";
            Date = DateTime.Parse("08.07.2005");
        }
        public Person(string name, string surname, DateTime date)
        {
            Name = name;
            Surname = surname;
            Date = date;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, DateOfBirth: {Date}";
        }
        public virtual string ToShortString()
        {
            return $"Name: {Name}, Surname: {Surname}";
        }
        
    }
}
