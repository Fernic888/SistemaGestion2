using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApplicationPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public void CrearProducto(Producto producto)
        {

        }
        [HttpPut]
        public void ModificarProducto()
        {

        }
        [HttpDelete]
        public void EliminarProducto() 
        {

        }
    }
}
