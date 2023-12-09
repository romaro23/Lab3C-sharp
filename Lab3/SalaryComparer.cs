using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class SalaryComparer: IComparer<Employee>
    {
        public int Compare(Employee e1, Employee e2)
        {
            //return e1.Salary.CompareTo(e2.Salary);
            if (e1.Salary > e2.Salary)
            {
                return 1;
            }
            if (e1.Salary < e2.Salary)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
    }
}
