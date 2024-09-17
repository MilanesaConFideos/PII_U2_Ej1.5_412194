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
    public class FacturaRepository : IFacturaRepository
    {
        FormaPagoRepository fpr = new FormaPagoRepository();
        DetalleFacturaRepository dfr = new DetalleFacturaRepository();
        public bool AddOne(Factura factura)
        {
            var parameters = new List<ParameterSQL>()
            {
                new ParameterSQL("fecha", factura.Fecha),
                new ParameterSQL("formaPago", factura.pFormaPago.IdFormaPago),
                new ParameterSQL("cliente", factura.Cliente)
            };
            int nro = DataHelper.GetInstance().ExecuteSPDMLR("SP_FACTURA_CREAR", parameters);
            Console.WriteLine(nro);
            bool detallesCommitable = true;
            foreach (DetalleFactura df in factura.Detalles) 
            { 
                detallesCommitable = dfr.AddOne(df, nro) > 0;
                if (!detallesCommitable)
                {
                    return false;                   
                }
            }
            return detallesCommitable;
        }
        public List<Factura> GetAll()
        {
            List<Factura> list = new List<Factura>();
            DataTable? table = new DataTable();
            table = DataHelper.GetInstance().ExecuteSPQuery("SP_FACTURA_TODO", null);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Factura f = new Factura();
                    f.NroFactura = (int)row[0];
                    f.Fecha = (DateTime)row[1];
                    f.pFormaPago = (FormaPago)fpr.GetOne((int)row[2]);
                    f.Detalles = (List<DetalleFactura>)dfr.GetAll((int)row[0]);
                    f.Cliente = (string)row[3];
                    list.Add(f);
                }
            }
            return list;
        }
        public Factura GetOne(int nroFactura)
        {
            Factura f = new Factura();
            DataTable? table = new DataTable();
            table = DataHelper.GetInstance().ExecuteSPQuery("SP_FACTURA_ID", new List<ParameterSQL>() { new ParameterSQL("idFactura", nroFactura) });
            DataRow row = table.Rows[0];
            f.NroFactura = (int)row[0];
            f.Fecha = (DateTime)row[1];
            f.pFormaPago = (FormaPago)fpr.GetOne((int)row[2]);
            f.Detalles = (List<DetalleFactura>)dfr.GetAll(f.NroFactura);
            return f;
        }
    }
}
