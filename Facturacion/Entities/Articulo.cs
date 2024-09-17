using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entities
{
    public class Articulo
    {
		private int idArticulo;
		private string nombre;
		private int precioUnitario;

		public Articulo()
		{
			nombre = string.Empty;
			precioUnitario = 0;
		}
		public Articulo(string nombre, int precioUnitario)
		{
			this.nombre = nombre;
			this.precioUnitario = precioUnitario;
		}
        public int IdArticulo
        {
            get { return idArticulo; }
            set { idArticulo = value; }
        }
        public int PrecioUnitario
		{
			get { return precioUnitario; }
			set { precioUnitario = value; }
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

        public override string ToString()
        {
            return nombre + "; $" + precioUnitario;
        }
    }
}
