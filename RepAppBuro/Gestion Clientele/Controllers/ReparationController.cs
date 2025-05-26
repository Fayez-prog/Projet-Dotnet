using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_Clientele.Controllers
{
    public class ReparationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReparationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var reparations = await _unitOfWork.Reparations.GetAllAsync();
            return View(reparations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var reparation = await _unitOfWork.Reparations.GetReparationWithDemandeAndFactureAsync(id);
            if (reparation == null) return NotFound();
            return View(reparation);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Demandes = new SelectList(await _unitOfWork.DemandesReparation.GetAllAsync(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reparation reparation)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Reparations.AddAsync(reparation);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Demandes = new SelectList(await _unitOfWork.DemandesReparation.GetAllAsync(), "Id", "Id", reparation.DemandeReparationId);
            return View(reparation);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reparation = await _unitOfWork.Reparations.GetByIdAsync(id);
            if (reparation == null) return NotFound();
            ViewBag.Demandes = new SelectList(await _unitOfWork.DemandesReparation.GetAllAsync(), "Id", "Id", reparation.DemandeReparationId);
            return View(reparation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reparation reparation)
        {
            if (id != reparation.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _unitOfWork.Reparations.Update(reparation);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Demandes = new SelectList(await _unitOfWork.DemandesReparation.GetAllAsync(), "Id", "Id", reparation.DemandeReparationId);
            return View(reparation);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var reparation = await _unitOfWork.Reparations.GetByIdAsync(id);
            if (reparation == null) return NotFound();
            return View(reparation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reparation = await _unitOfWork.Reparations.GetByIdAsync(id);
            _unitOfWork.Reparations.Remove(reparation);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GenerateFacture(int id)
        {
            var reparation = await _unitOfWork.Reparations.GetByIdAsync(id);
            if (reparation == null) return NotFound();

            // Logique de génération de facture
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
