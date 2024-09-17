using Facturacion.Entities;
using Facturacion.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Services
{
    public static class FacturacionManager
    {
        private static ArticuloRepository _aRepo = new ArticuloRepository();
        private static FacturaRepository _fRepo = new FacturaRepository();
        private static DetalleFacturaRepository _dRepo = new DetalleFacturaRepository();
        private static FormaPagoRepository _pRepo = new FormaPagoRepository();

        public static List<Factura> GetEveryFactura()
        {
            return _fRepo.GetAll();
        }
        public static bool SaveFactura(Factura f)
        {
            return _fRepo.AddOne(f);
        }
        public static Factura GetOneFactura(int id)
        {
            return _fRepo.GetOne(id);
        }
        public static List<FormaPago> GetAllFormaPago()
        {
            return _pRepo.GetAll();
        }
        public static List<Articulo> GetAllArticulos()
        {
            return _aRepo.GetAll();
        }
        public static bool CreateFactura()
        {
            bool another = true;
            int i = 1;
            List<FormaPago> fps = new List<FormaPago>();
            fps = GetAllFormaPago();
            List<Articulo> aList = new List<Articulo>();
            aList = GetAllArticulos();
            List<DetalleFactura> detalles = new List<DetalleFactura>();
            Factura f = new Factura();
            f.Fecha = DateTime.Today;
            Console.WriteLine("Ingrese el nombre del cliente: ");
            f.Cliente = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Elija la forma de Pago: ");
            foreach (FormaPago fp in fps)
            {
                Console.WriteLine(i + ") " + fp.ToString());
                i++;
            }
            int formaPago = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            f.pFormaPago = fps[formaPago - 1];
            do
            {
                int j = 1;
                DetalleFactura detalleFactura = new DetalleFactura();
                Console.WriteLine("Elija el articulo: ");
                foreach (Articulo art in aList)
                {
                    Console.WriteLine(j + ") " + art.ToString());
                    j++;
                }
                int a = 1;
                a = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                detalleFactura.pArticulo = aList[a - 1];
                Console.WriteLine("Cuantas unidades desea comprar?");
                detalleFactura.Cantidad = Convert.ToInt32(Console.ReadLine());
                detalles.Add(detalleFactura);
                Console.Clear();
                Console.WriteLine("Hay otro articulo a comprar? \n\t 1) Si\n\t2) No");
                string e = Console.ReadLine();
                Console.Clear();
                if (e != "1")
                {
                    f.Detalles = detalles;
                    another = false;
                }
            } while (another);
            return SaveFactura(f);
        }
    }
}
