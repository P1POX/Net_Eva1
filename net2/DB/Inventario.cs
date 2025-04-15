using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using net2.Model;

namespace net2.DB
{
    class Inventario
    {
        //conexion: instacia de la base de datos
        public List<Item> Data { set; get; }

        public Inventario()
        {
            Data = new List<Item>();
        }

        public override string ToString()
        {
            string str = "";
            if (this.Data.Count != 0)
            {
                str += "Lista de productos\n";
                str += "+" + string.Concat(Enumerable.Repeat("-", 20)) + "+\n";
                str += "| ID | Nombre | Precio | Stock disponible\n";
                foreach (Item item in this.Data)
                {
                    str += $"{item}\n";
                }
            } else
            {
                str += "No hay productos en el inventario\n";
            }

            return str;
        }

        public bool ExistProductId(int id)
        {
            foreach (Item item in this.Data)
            {
                if (item.Producto.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Item getItemWithId(int id)
        {
            foreach (Item item in this.Data)
            {
                if (item.Producto.Id == id)
                {
                    return item;
                }
            }
            return new Item();
        }

        public bool ExistProductName(string name)
        {
            foreach (Item item in this.Data)
            {
                if (item.Producto.Name.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }

        public string SearchProducts(string name)
        {
            bool found = ExistProductName(name);
            if (found)
            {
                string str = "Productos encontrados\n";
                str += "+" + string.Concat(Enumerable.Repeat("-", 20)) + "+\n";
                str += "| ID | Nombre | Precio | Stock disponible\n";
                foreach (Item item in this.Data)
                {
                    if (item.Producto.Name.Contains(name))
                    {
                        str += $"{item}\n";
                    }
                }
                return str;
            }
            else
            {
                return "No se ecnontraron productos con ese nombre\n";
            }
        }

        public void DeleteProduct(int id)
        {
            int index = -1;
            foreach (Item item in this.Data)
            {
                if (item.Producto.Id == id)
                {
                    index = this.Data.IndexOf(item);
                }
            }
            try
            {
                this.Data.RemoveAt(index);
            } catch { }
        }
    }
}
