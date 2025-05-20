using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_Clientele.Controllers
{
    public class AppareilController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppareilController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            // Remplacer par:
            var appareils = await _unitOfWork.Appareils.GetAllAppareilsWithClientsAsync();
            return View(appareils);
        }

        public async Task<IActionResult> Details(int id)
        {
            var appareil = await _unitOfWork.Appareils.GetAppareilWithClientAsync(id);
            if (appareil == null) return NotFound();
            return View(appareil);
        }

        public async Task<IActionResult> Create()
        {
            // Initialiser ViewBag.Clients avant de retourner la vue
            ViewBag.Clients = new SelectList(await _unitOfWork.Clients.GetAllAsync(), "Id", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appareil appareil)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Appareils.AddAsync(appareil);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }

            // Réinitialiser ViewBag.Clients en cas d'erreur de validation
            ViewBag.Clients = new SelectList(await _unitOfWork.Clients.GetAllAsync(), "Id", "Nom", appareil.ClientId);
            return View(appareil);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appareil = await _unitOfWork.Appareils.GetByIdAsync(id);
            if (appareil == null) return NotFound();
            ViewBag.Clients = new SelectList(await _unitOfWork.Clients.GetAllAsync(), "Id", "Nom", appareil.ClientId);
            return View(appareil);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appareil appareil)
        {
            if (id != appareil.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _unitOfWork.Appareils.Update(appareil);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clients = new SelectList(await _unitOfWork.Clients.GetAllAsync(), "Id", "Nom", appareil.ClientId);
            return View(appareil);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var appareil = await _unitOfWork.Appareils.GetByIdAsync(id);
            if (appareil == null) return NotFound();
            return View(appareil);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appareil = await _unitOfWork.Appareils.GetByIdAsync(id);
            _unitOfWork.Appareils.Remove(appareil);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

