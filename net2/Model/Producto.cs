using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net2.Model
{
    class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Producto()
        {

        }

        public Producto(int id, string name, string description, int price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"{this.Id} | {this.Name} | {this.Description} | {this.Price}";
        }
    }
}
