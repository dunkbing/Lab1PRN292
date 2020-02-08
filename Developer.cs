using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Developer:Employee {
        public string Major { get; set; }
        public Developer(int id, string name, double salary, string major):base(id, name, salary) {
            Major = major;
        }
        public Developer() {

        }
        public override double GetSalary() {
            int bonus = 1;
            switch (Major) {
                case "C#": bonus = 3; break;
                case "Java": bonus = 3; break;
                default:
                    bonus = 1;
                    break;
            }
            return base.Salary*(12+bonus);
        }
        public override string ToString() {
            return "D"+base.ToString()+Major;
        }
        public override bool Equals(object obj) {
            Developer d = obj as Developer;
            return base.Equals(obj) && this.Major == d.Major;
        }
        public override Employee CreateEmployee() {
            Employee e = base.CreateEmployee();
            Console.WriteLine("Enter major:");
            string major = Console.ReadLine();
            return new Developer(e.ID, e.Name, e.Salary, major);
        }
    }
}
