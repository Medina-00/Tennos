using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tennos_Prueba.core.Domain.Entidades;
using Tennos_Prueba.Infraestructura.persistence.Repository;

namespace Tennos_Prueba.web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }
        // GET: ProductoController
        public async Task<ActionResult> Index()
        {
            return View( await productoRepository.GetAllAsync());
        }

        // GET: ProductoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View( await productoRepository.GetByIdAsync(id));
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Productos collection)
        {
            try
            {
                await productoRepository.AddAsync(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await productoRepository.GetByIdAsync(id));
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Productos collection)
        {
            try
            {
                await productoRepository.UpdateAsync(collection,id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await productoRepository.GetByIdAsync(id));
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Productos collection)
        {
            try
            {
                await productoRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
