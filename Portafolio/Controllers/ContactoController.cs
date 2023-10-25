using Microsoft.AspNetCore.Mvc;
using Portafolio.Datos;

namespace Portafolio.Controllers
{
    public class ContactoController : Controller
    {
        ContactoDatos _proyectoDatos = new ContactoDatos();
        public IActionResult Listar()
        {

            var lista = _proyectoDatos.Lista();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Insertar()
        {

            return View();
        }
        public IActionResult Ejemplo()
        {

            return View();
        }
    }
}
