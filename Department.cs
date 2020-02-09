using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    
    public delegate void NumberOfMembersChanged();
    public delegate void ManagerChangedHandler();
    [Serializable]
    class Department<T, G>:ICanDisplay {
        public event ManagerChangedHandler ManagerChanged;
       
        public T Code { get; set; }
        public string Name { get; set; }
        private G manager;
        private List<G> members;
        public G Manager {
            get { return manager; }
            set {
                try {
                    if (!manager.Equals(value)) ManagerChanged();
                    manager = value;
                } catch(NullReferenceException e) {
                    //Console.WriteLine(e.StackTrace);
                }
                finally {
                    manager = value;
                }
            }
        }
        protected virtual void OnManagerChanged(DepartmentEventArgs<G> e) {

        }
        public List<G> Members {
            get { return members; }
            set {
                members = value;
            }
        }

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
                Console.WriteLine("file written successfully");
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
            Console.WriteLine($"{Code}\n{Name}\n{Manager}");
            if (Members != null) {
                foreach (G item in Members) {
                    Console.WriteLine(item);
                }
            }
            
        }

        //Events

    }
}
