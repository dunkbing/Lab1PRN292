using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class DepartmentEventArgs<G>:EventArgs {
        public G Manager { get; set; }
        public List<G> Members { get; set; }
        public DepartmentEventArgs(G manager, List<G> members) {
            Manager = manager;
            Members = members;
        }
    }
}
