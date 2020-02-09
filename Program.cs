using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Program {
        static void OnManagerChangedHandler(Employee oldEmp, Employee newEmp) {

        }
        static void Main(string[] args) {
            Department<string, Employee> department = new Department<string, Employee>();
            department.OnNumberOfMembersChanged += (sender, e) => {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"number of members changed to {e.Members.Count}");
                Console.ResetColor();
            };
            department.ManagerChanged += (m) => {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"manager changed to {m.Name}");
                Console.ResetColor();
            };
            department.Code = "D01";
            department.Name = "Department of Testing";
            department.Manager = new Tester(3, "Hoang", 1200, 10);
            department.Members = new List<Employee>();
            department.AddMember(new Tester(1, "Trung", 1000, 7));
            department.AddMember(new Tester(4, "Lan", 800, 5));
            department.AddMember(new Tester(2, "Chinh", 850, 4));
            Console.WriteLine("before sorting:");
            department.Display();
            Console.WriteLine("after sorting by id:");
            department.Members.Sort(Employee.Empty);
            department.Display();
            Console.WriteLine("after sorting by name:");
            department.Members.Sort(delegate(Employee x, Employee y) {
                return x.Name.CompareTo(y.Name);
            });
            department.Display();
            //department.AddMember(new Tester());
            department.Manager = new Tester(1, "Hoang2", 1200, 10);
            department.WriteToFile("../../department.txt");
            department.ReadFromFile("../../department.txt");
            //department.ManagerChanged += (s, e) => Console.WriteLine("Manager changed to "+e.Manager.Name);
            //department.Manager = new Employee(8, "binh", 1000);
            /*Department<string, Employee> dep = new Department<string, Employee>();
            while (true) {
                Menu();
                string opt = Console.ReadLine();
                Console.WriteLine(opt);
                switch (opt) {
                    case "1":
                        dep = new Department<string, Employee>();
                        dep.ManagerChanged += () => {
                            Console.WriteLine($"manager changed");
                        };
                        Console.ReadLine();
                        break;
                    case "2":
                        try {
                            dep.ReadFromFile("../../department.txt");
                            dep.Display();
                            Console.ReadLine();
                        }
                        catch (Exception e) {
                            Console.WriteLine(e.StackTrace);
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        MenuCase3();
                        string optCase3 = Console.ReadLine();
                        switch (optCase3) {
                            case "1":
                                string job = dep.Name.Split(' ')[2].ToLower();
                                Console.WriteLine($"create a {job} job");
                                switch (job) {
                                    case "testing": dep.AddMember(new Tester()); break;
                                    case "developing": dep.AddMember(new Developer().CreateEmployee()); break;
                                    default: dep.AddMember(new Employee().CreateEmployee()); break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("remove an employee(from 0 to {0})", dep.Members.Count);
                                dep.Members.Remove(dep.Members[Convert.ToInt32(Console.ReadLine())]);
                                Console.WriteLine(dep.Members.Count);
                                Console.ReadLine();
                                break;
                            case "3":
                                dep.Manager = new Employee().CreateEmployee();
                                break;
                        }
                        break;
                    case "4":
                        break;
                    case "5":
                        dep.WriteToFile("../../department.txt");
                        Console.ReadKey();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    case "7":
                        dep.Display();
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }*/
        }
        static void Menu() {
            Console.WriteLine("1. Create a deparment");
            Console.WriteLine("2. Read information of this department from file");
            Console.WriteLine("3. Add/ Remove/ Edit manager and members of the department");
            Console.WriteLine("4. Sort list of department by ID (or Name, or Salary)");
            Console.WriteLine("5. Write edited information of this department into file.");
            Console.WriteLine("6. Exit");
        }
        static void MenuCase3() {
            Console.WriteLine("1. Add a member");
            Console.WriteLine("2. Remove a member");
            Console.WriteLine("3. Edit manager and members");
        }
        public static void Display() {
            new Department<int, Employee>().Display();
            foreach (var item in new Department<int, Employee>().Members) {
                Console.WriteLine(item);
            }
        }
        }
}
