using Facturacion.Entities;
using Facturacion.Repositories.Contracts;
using Facturacion.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ej_1._5_U2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        List<Factura> lstFactura = new List<Factura>();
        private readonly IFacturaRepository factura = new FacturaRepository();

        [HttpGet]
        public IActionResult GetFacturas()
        {
            lstFactura = factura.GetAll();
            return Ok(lstFactura);
        }

        [HttpPost]
        public IActionResult PostFacturas(Factura f)
        {
            if (factura.AddOne(f))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
