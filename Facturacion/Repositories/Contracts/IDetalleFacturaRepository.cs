using Facturacion.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Repositories.Contracts
{
    public interface IDetalleFacturaRepository
    {
        int AddOne(DetalleFactura detalleFactura, int nroFactura);
        List<DetalleFactura> GetAll(int idFactura);
    }
}
