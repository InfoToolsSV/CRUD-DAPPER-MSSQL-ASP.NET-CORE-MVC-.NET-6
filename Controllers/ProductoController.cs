using Microsoft.AspNetCore.Mvc;
using MVC_Dapper.Data;
using MVC_Dapper.Models;

namespace MVC_Dapper.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProducto _iproducto;

        public ProductoController(IProducto iproducto)
        {
            _iproducto = iproducto;
        }

        public IActionResult Index()
        {
            var producto = _iproducto.ObtenerProductos();
            return View(producto);
        }

        public IActionResult Detalle(int id)
        {
            var producto = _iproducto.ObtenerProductoPorId(id);
            return View(producto);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            _iproducto.InsertarProducto(producto);
            return RedirectToAction("Index");
        }


        public IActionResult Editar(int id)
        {
            var producto = _iproducto.ObtenerProductoPorId(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            _iproducto.ActualizarProducto(producto);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var producto = _iproducto.ObtenerProductoPorId(id);

            if (producto == null)
                return NotFound();


            return View(producto);
        }

        [HttpPost]
        public IActionResult EliminarConfirmado(int id)
        {
            _iproducto.EliminarProducto(id);
            return RedirectToAction("Index");
        }

    }
}