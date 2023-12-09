using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab3.Employee;
using static Lab3.Person;

namespace Lab3
{
    internal class EmployeeCollection
    {
        private List<Employee> employees = new List<Employee>();

        public List<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }
        public EmployeeCollection()
        {
            Employees.Add(new Employee());
        }
        public EmployeeCollection(Employee employee)
        {
            Employees.Add(employee);
        }
        public void AddDefaults()
        {
            Employees.Add(new Employee());
        }
        public void AddEmployees(params Employee[] employees) 
        {
            for(int i = 0; i < employees.Length; i++)
            {
                Employees.Add(employees[i]);
            }
        }
        public override string ToString()
        {
            return $"{string.Join(";", Employees)}";
        }
        public string ToShortString()
        {
            string result = "";
            foreach (var employee in Employees)
            {
                result += $"{employee.PersonData}, {employee.Position}, {employee.WorkTime}, Salary: {employee.Salary}, NumberOfDiplomas: {employee.Diplomas.Count}, NumberOfWorks: {employee.Experiences.Count}";
            }
            return result;
        }
    }
}
