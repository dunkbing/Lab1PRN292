using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    
    public delegate void OnNumberOfMembersChanged();
    [Serializable]
    class Department<T, G>:ICanDisplay {
        public event EventHandler<DepartmentEventArgs<G>> ManagerChanged;
       
        public T Code { get; set; }
        public string Name { get; set; }
        private G manager;
        public G Manager {
            get { return manager; }
            set {
                var handle = ManagerChanged as EventHandler<DepartmentEventArgs<G>>;
                if(handle != null && !manager.Equals(value)) {
                    handle(this, new DepartmentEventArgs<G>(value, Members));
                }
                manager = value;
            }
        }
        public List<G> Members { get; set; }

        //Methods
        public void ReadFromFile(string fileName) {
            using (Stream stream = File.Open(fileName, FileMode.Open)) {
                var bformatter = new BinaryFormatter();
                Department<T, G> d = (Department<T, G>)bformatter.Deserialize(stream);
                Code = d.Code;
                Name = d.Name;
                Manager = d.Manager;
                Members = d.Members;
                stream.Close();
            }
        }

        public void WriteToFile(string fileName) {
            using (Stream stream = File.Open(fileName, FileMode.Create)) {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, this);
                stream.Close();
            }
        }

        public void Sort(IComparer<G> comparer) {
            Members.Sort(comparer);
        }

        public double GetAvgOfSalary() {
            double salarySum = 0;
            foreach (G g in Members) {
                if(typeof(G) == typeof(Employee)) {
                    Employee e = (Employee)(object)g;
                    salarySum += e.GetSalary();
                }
            }
            return salarySum / Members.Count;
        }
        public void AddMember(G item) {
            try {
                Members.Add(item);
            }
            catch (NullReferenceException e) {
                Console.WriteLine(e.Message);
            }
        }
        public void RemoveMember(G item) {
            Members.Remove(item);
        }
        public void Display() {
            Console.WriteLine(string.Format("{0}\n{1}\n{2}", Code, Name, Manager));
            foreach (G item in Members) {
                Console.WriteLine(item);
            }
        }

        //Events

    }
}
