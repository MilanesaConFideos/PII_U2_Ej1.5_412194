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
    public class FormaPagoRepository : IFormaPagoRepository
    {
        public List<FormaPago> GetAll()
        {
            List<FormaPago> list = new List<FormaPago>();
            DataTable? table = new DataTable();
            table = DataHelper.GetInstance().ExecuteSPQuery("SP_FORMAPAGO_TODO", null);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    FormaPago fp = new FormaPago();
                    fp.IdFormaPago = (int)row[0];
                    fp.Nombre = (string)row[1];
                    list.Add(fp);
                }
            }
            return list;
        }
        public FormaPago GetOne(int id)
        {
            FormaPago fp = new FormaPago();
            DataTable? table = new DataTable();
            table = DataHelper.GetInstance().ExecuteSPQuery("SP_FORMAPAGO_ID", new List<ParameterSQL> { new ParameterSQL("id", id)});
            DataRow row = table.Rows[0];
            fp.IdFormaPago = (int)row[0];
            fp.Nombre = (string)row[1];
            return fp;
        }
    }
}
