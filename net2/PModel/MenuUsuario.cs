using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net2.Model;


namespace net2.PModel
{
    class MenuUsuario
    {
        public string Cabecera;
        public List<Opcion> Opciones;

        public MenuUsuario()
        {
            this.Opciones = new List<Opcion>();
        }

        public override string ToString()
        {
            string str = "";
            string salto = "\n";
            str += this.Cabecera + salto;
            str += "+" + string.Concat(Enumerable.Repeat("-", 20)) + "+" + salto;
            foreach (Opcion item in this.Opciones)
            {
                str += item.ToString() + salto;
            }

            return str;
        }

    }
}
