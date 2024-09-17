using Facturacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Repositories.Contracts
{
    public interface IArticuloRepository
    {
        Articulo GetOne(int id);
        List<Articulo> GetAll();
    }
}
