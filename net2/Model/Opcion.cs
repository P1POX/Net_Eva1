using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net2.Model
{
    class Opcion
    {
        public Opcion() { }
        public Opcion(int id, string nombre)
        {
            this.Id = id;
            this.Name = nombre;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"| {this.Id} | {this.Name}";
        }
    }
}
