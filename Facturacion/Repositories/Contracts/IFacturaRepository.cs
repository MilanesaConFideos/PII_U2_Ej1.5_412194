using Facturacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Repositories.Contracts
{
    public interface IFacturaRepository
    {
            bool AddOne(Factura factura);
            Factura GetOne(int nroFactura);
            List<Factura> GetAll();
    }
}
