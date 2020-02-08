using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    [Serializable]
    class Tester:Employee {
        public int Exp { get; set; }
        public Tester(int id, string name, double salary, int exp):base(id, name, salary) {
            Exp = exp;
        }
        public Tester() {

        }
        public override double GetSalary() {
            return base.Salary * (12 + Exp * 0.2);
        }
        public override string ToString() {
            return "T"+base.ToString()+Exp;
        }
        public override bool Equals(object obj) {
            Tester t = obj as Tester;
            return base.Equals(obj) && this.Exp == t.Exp;
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        public override Employee CreateEmployee() {
            Employee e = base.CreateEmployee();
            int exp = Convert.ToInt32(Console.ReadLine());
            return new Tester(e.ID, e.Name, e.Salary, exp);
        }
    }
}
