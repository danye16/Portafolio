using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Datos;
using Portafolio.Models;

namespace Portafolio.Controllers
{
    public class ProyectoController : Controller
    {
        ProyectoDatos _proyectoDatos = new ProyectoDatos();
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

        [HttpPost]
        public IActionResult Insertar(ProyectoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool respuesta = _proyectoDatos.GuardarProyecto(model);
            // var respuesta = _instalacionDatos.GuardarInstalacion(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int IDProyecto)
        {
            //para obtener y mostrar el contacto a modificar
            ProyectoModel _proyecto = _proyectoDatos.ConsultarProyecto(IDProyecto);
            return View(_proyecto);
        }
        [HttpPost]
        public IActionResult Editar(ProyectoModel model)
        {
            //Para obtener los datos que se editaron del formulario y enviarlo en la base de datos
            if (ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _proyectoDatos.EditarProyecto(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        //Contraolador de Eliminar
        public IActionResult Eliminar(int IdProyecto)
        {
            //para obtener y mostrar la instalacion a eliminar
            var _instalacion = _proyectoDatos.ConsultarProyecto(IdProyecto);
            return View(_instalacion);
        }

        [HttpPost]
        public IActionResult Eliminar(ProyectoModel model)
        {
            //Para obtener los datos que se van a eliminar del formulario y enviarlo en la base de datos
            var respuesta = _proyectoDatos.EliminarProyecto(model.IdProyecto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            { return View(); }
        }
    }

}
