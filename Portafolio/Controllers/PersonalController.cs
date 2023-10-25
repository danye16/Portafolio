using Microsoft.AspNetCore.Mvc;
using Portafolio.Datos;
using Portafolio.Models;
namespace Portafolio.Controllers
{
    public class PersonalController : Controller
    {
        PersonalDatos _proyectoDatos = new PersonalDatos();
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
