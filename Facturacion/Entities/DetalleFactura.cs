using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entities
{
    public class DetalleFactura
    {
        public int idDetalle;
        private Articulo articulo;
        private int cantidad;
        public DetalleFactura()
        {
            articulo = new Articulo();
            cantidad = 0;
        }
        public DetalleFactura(Articulo articulo, int cantidad)
        {
            this.articulo = articulo;
            this.cantidad = cantidad;
        }
        public int IdDetalle
        {
            get { return this.idDetalle; }
            set { idDetalle = value; }
        }
        public Articulo pArticulo
        {
            get { return articulo; }
            set { articulo = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public override string ToString()
        {
            return cantidad + " x " + articulo.ToString();
        }

    }
}
