using Facturacion.Entities;
using Facturacion.Repositories.Contracts;
using Facturacion.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Repositories.Implementations
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        ArticuloRepository ar = new ArticuloRepository();
        public int AddOne(DetalleFactura detalleFactura, int nroFactura)
        {
            List<ParameterSQL> parameters = new List<ParameterSQL>()
            {
                new ParameterSQL("idFactura", nroFactura),
                new ParameterSQL("articulo", detalleFactura.pArticulo.IdArticulo),
                new ParameterSQL("cantidad", detalleFactura.Cantidad)
            };
            int rows = DataHelper.GetInstance().ExecuteSPDML("SP_DETALLE_CREAR", parameters);
            return rows;
        }
        public List<DetalleFactura> GetAll(int idFactura)
        {
            List<DetalleFactura> list = new List<DetalleFactura>();
            DataTable? table = new DataTable();
            table = DataHelper.GetInstance().ExecuteSPQuery("SP_DETALLE_IDFACTURA", new List<ParameterSQL>() { new ParameterSQL("idFactura", idFactura) });
            if (table != null) 
            { 
                foreach (DataRow row in table.Rows)
                {
                    DetalleFactura df = new DetalleFactura();
                    df.idDetalle = (int)row[0];                    
                    df.pArticulo = (Articulo)ar.GetOne((int)row[2]);
                    df.Cantidad = (int)row[3];
                    list.Add(df);
                }
            }
            return list;
        }
    }
}
