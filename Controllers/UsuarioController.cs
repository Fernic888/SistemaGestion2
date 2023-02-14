using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;


namespace WebApplicationPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //[HttpGet("login")]
        //public Usuario Login(string usuario, string contrasena) //[FromQuery]
        //{
        //    Console.WriteLine();
        //    return null;
        //}
        [HttpPost]
        public void CrearUsuario(Usuario usuarioNuevo)
        {
            ManejadorUsuario.InsertarUsuario(usuarioNuevo);
        }
        [HttpPut]
        public void ModificarUsuario()
        {

        }
    }
}
