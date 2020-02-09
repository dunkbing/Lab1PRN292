using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    [Serializable]
    class Employee : ICanDisplay, IComparer<Employee>{
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public Employee(int id, string name, double salary) {
            ID = id;
            Name = name;
            Salary = salary;
        }
        public Employee() {
            Console.WriteLine("Enter ID:");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter salary:");
            Salary = Convert.ToDouble(Console.ReadLine());
        }
        public void Display() {
            Console.WriteLine(this);
        }
        
        public virtual double GetSalary() {
            return Salary * 12;
        }
        public override string ToString() {
            return string.Format("|{0}|{1}|{2}|", ID, Name, GetSalary());
        }

        public override bool Equals(object obj) {
            Employee e = obj as Employee;
            return this.ID == e.ID && this.Name == e.Name && this.Salary == e.Salary;
        }

        public int Compare(Employee x, Employee y) {
            return x.ID - y.ID;
        }

        public virtual Employee CreateEmployee() {
            Console.WriteLine("Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter salary:");
            double salary = Convert.ToDouble(Console.ReadLine());
            return new Employee(id, name, salary);
        }
    }
}
