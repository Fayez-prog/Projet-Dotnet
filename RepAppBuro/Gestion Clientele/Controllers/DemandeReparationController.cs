using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_Clientele.Controllers
{
    public class DemandeReparationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DemandeReparationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var demandes = await _unitOfWork.DemandesReparation.GetAllWithClientAndAppareilAsync();
            return View(demandes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var demande = await _unitOfWork.DemandesReparation.GetDemandeWithClientAndAppareilAsync(id);
            var demandes = await _unitOfWork.DemandesReparation.GetDemandeWithReparationsAsync(id);
            if (demande == null & demandes == null) return NotFound();
            return View(demande);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = new SelectList(await _unitOfWork.Clients.GetAllAsync(), "Id", "Nom");
            ViewBag.Appareils = new SelectList(await _unitOfWork.Appareils.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DemandeReparation demande)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.DemandesReparation.AddAsync(demande);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clients = new SelectList(await _unitOfWork.Clients.GetAllAsync(), "Id", "Nom", demande.ClientId);
            ViewBag.Appareils = new SelectList(await _unitOfWork.Appareils.GetAllAsync(), "Id", "Name", demande.AppareilId);
            return View(demande);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var demande = await _unitOfWork.DemandesReparation.GetByIdAsync(id);
            if (demande == null) return NotFound();
            ViewBag.Clients = new SelectList(await _unitOfWork.Clients.GetAllAsync(), "Id", "Nom", demande.ClientId);
            ViewBag.Appareils = new SelectList(await _unitOfWork.Appareils.GetAllAsync(), "Id", "Name", demande.AppareilId);
            return View(demande);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DemandeReparation demande)
        {
            if (id != demande.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _unitOfWork.DemandesReparation.Update(demande);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clients = new SelectList(await _unitOfWork.Clients.GetAllAsync(), "Id", "Nom", demande.ClientId);
            ViewBag.Appareils = new SelectList(await _unitOfWork.Appareils.GetAllAsync(), "Id", "Name", demande.AppareilId);
            return View(demande);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var demande = await _unitOfWork.DemandesReparation.GetDemandeWithClientAndAppareilAsync(id);
            if (demande == null) return NotFound();
            return View(demande);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demande = await _unitOfWork.DemandesReparation.GetDemandeWithClientAndAppareilAsync(id);
            _unitOfWork.DemandesReparation.Remove(demande);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeStatus(int id, string newStatus)
        {
            var demande = await _unitOfWork.DemandesReparation.GetByIdAsync(id);
            if (demande == null) return NotFound();

            demande.Etat = newStatus;
            _unitOfWork.DemandesReparation.Update(demande);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
 
