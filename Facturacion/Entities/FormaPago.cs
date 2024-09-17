using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entities
{
    public class FormaPago
    {
        private int idFormaPago;
        private string nombre;
        public FormaPago() 
        {
            nombre = string.Empty;
        }
        public FormaPago(string nombre)
        {
            this.nombre = nombre;
        }
        public int IdFormaPago
        {
            get { return idFormaPago; }
            set { idFormaPago = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public override string ToString()
        {
            return nombre;
        }

    }
}
