using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturacion.Entities;

namespace Facturacion.Repositories.Contracts
{
    public interface IFormaPagoRepository   
    {
        List<FormaPago> GetAll();
        FormaPago GetOne(int id);
    }
}
