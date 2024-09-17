using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entities
{
    public class Factura
    {
        private int nroFactura;
        private DateTime fecha;
        private FormaPago formaPago;
        private string cliente;
        private List<DetalleFactura> detalles;
        public Factura()
        {
            cliente = string.Empty;
        }
        public Factura(int nroFactura, DateTime fecha, FormaPago formaPago, string cliente, List<DetalleFactura> detalles)
        {
            this.nroFactura = nroFactura;
            this.fecha = fecha;
            this.formaPago = formaPago;
            this.cliente = cliente;
            this.detalles = detalles;
        }
        public int NroFactura
        {
            get { return nroFactura; }
            set { nroFactura = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public FormaPago pFormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public List<DetalleFactura> Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }
        public override string ToString()
        {
            string cadenaDetalles = "";
            foreach (DetalleFactura df in detalles)
            {
                cadenaDetalles = cadenaDetalles + "\t" + df.ToString() + "\n";
            }
            return "[" + nroFactura + "] CLIENTE: " + cliente.ToString() + "; FECHA: " + fecha.ToShortDateString() + "; FORMA DE PAGO: " + formaPago.ToString() + " DETALLES: \n" + cadenaDetalles;
        }
    }
}
