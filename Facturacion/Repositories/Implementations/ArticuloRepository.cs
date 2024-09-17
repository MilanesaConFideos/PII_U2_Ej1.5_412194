using Facturacion.Entities;
using Facturacion.Repositories.Contracts;
using Facturacion.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Repositories.Implementations
{
    public class ArticuloRepository : IArticuloRepository
    {
        public List<Articulo> GetAll()
        {
            List<Articulo> list = new List<Articulo>();
            DataTable? table = new DataTable();
            table = DataHelper.GetInstance().ExecuteSPQuery("SP_ARTICULO_TODO", null);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Articulo a = new Articulo();
                    a.IdArticulo = (int)row[0];
                    a.Nombre = (string) row[1];
                    a.PrecioUnitario = (int)row[2];
                    list.Add(a);
                }
            }
            return list;
        }
        public Articulo GetOne(int id)
        {
            Articulo a = new Articulo();
            DataTable? table = new DataTable();
            table = DataHelper.GetInstance().ExecuteSPQuery("SP_ARTICULO_ID", new List<ParameterSQL>() { new ParameterSQL("id", id) });
            DataRow row = table.Rows[0];
            a.IdArticulo = (int)row[0];
            a.Nombre = (string)row[1];
            a.PrecioUnitario = (int)row[2];
            return a;
        }
    }
}
