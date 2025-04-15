using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net2.Model
{
    class Item
    {
        public Producto Producto { get; set; }
        public int cantidad { get; set; }

        public Item()
        {

        }
        public Item(Producto p, int amount)
        {
            this.Producto = p;
            this.cantidad = amount;
        }

        public override string ToString()
        {
            return $"| {this.Producto.Id} | {this.Producto.Name} | {this.Producto.Price} | {this.cantidad}";
        }
    }
}
