using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_NET
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(string id, string name, string email, string phone, string address, int salary, string date)
        {
            this.Id = id;
            this.Name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.salary = salary;
            this.hire_date = date;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int salary { get; set; }
        public string hire_date { get; set; }

    }
}
