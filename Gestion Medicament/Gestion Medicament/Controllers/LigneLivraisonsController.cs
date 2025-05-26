using Gestion_Medicament.Data;
using Gestion_Medicament.Entity.Interface;
using Gestion_Medicament.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Medicament.Controllers
{
    public class LigneLivraisonsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LigneLivraisonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: LigneLivraisons
        public async Task<IActionResult> Index()
        {
            var lignes = await _unitOfWork.LigneLivraisons.GetAllAsync();
            foreach (var ligne in lignes)
            {
                await _unitOfWork.LigneLivraisons.IncludeMedicamentAndLivraison(ligne);
            }
            return View(lignes);
        }

        // GET: LigneLivraisons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ligneLivraison = await _unitOfWork.LigneLivraisons.GetByIdAsync(id);
            if (ligneLivraison == null)
            {
                return NotFound();
            }

            await _unitOfWork.LigneLivraisons.IncludeMedicamentAndLivraison(ligneLivraison);
            return View(ligneLivraison);
        }

        // GET: LigneLivraisons/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        // POST: LigneLivraisons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    [Bind("Id,Quantite,Description,RefMed,NumLiv")] LigneLivraison ligneLivraison)
        {
            // Vérification manuelle des existences
            var medicament = await _unitOfWork.Medicaments.GetByIdAsync(ligneLivraison.RefMed);
            var livraison = await _unitOfWork.Livraisons.GetByIdAsync(ligneLivraison.NumLiv);

            if (medicament == null)
                ModelState.AddModelError("RefMed", "Médicament introuvable");
            if (livraison == null)
                ModelState.AddModelError("NumLiv", "Livraison introuvable");

            if (ModelState.IsValid)
            {
                try
                {
                    // Associer les entités chargées
                    ligneLivraison.Medicament = medicament;
                    ligneLivraison.Livraison = livraison;

                    await _unitOfWork.LigneLivraisons.AddAsync(ligneLivraison);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", $"Erreur base de données: {ex.InnerException?.Message}");
                }
            }

            await PopulateDropdowns(ligneLivraison.RefMed, ligneLivraison.NumLiv);
            return View(ligneLivraison);
        }

        // GET: LigneLivraisons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ligneLivraison = await _unitOfWork.LigneLivraisons.GetByIdAsync(id);
            if (ligneLivraison == null)
            {
                return NotFound();
            }

            await PopulateDropdowns(ligneLivraison.RefMed, ligneLivraison.NumLiv);
            return View(ligneLivraison);
        }

        // POST: LigneLivraisons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantite,Description,RefMed,NumLiv")] LigneLivraison ligneLivraison)
        {
            if (id != ligneLivraison.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.LigneLivraisons.UpdateAsync(ligneLivraison);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LigneLivraisonExists(ligneLivraison.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdowns(ligneLivraison.RefMed, ligneLivraison.NumLiv);
            return View(ligneLivraison);
        }

        // GET: LigneLivraisons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ligneLivraison = await _unitOfWork.LigneLivraisons.GetByIdAsync(id);
            if (ligneLivraison == null)
            {
                return NotFound();
            }

            await _unitOfWork.LigneLivraisons.IncludeMedicamentAndLivraison(ligneLivraison);
            return View(ligneLivraison);
        }

        // POST: LigneLivraisons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.LigneLivraisons.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: LigneLivraisons/ByLivraison/numLiv
        public async Task<IActionResult> ByLivraison(string numLiv)
        {
            if (string.IsNullOrEmpty(numLiv))
            {
                return NotFound();
            }

            var lignes = await _unitOfWork.LigneLivraisons.GetLignesByLivraisonAsync(numLiv);
            ViewBag.NumLiv = numLiv;
            return View(lignes);
        }

        // GET: LigneLivraisons/ByMedicament/refMed
        public async Task<IActionResult> ByMedicament(string refMed)
        {
            if (string.IsNullOrEmpty(refMed))
            {
                return NotFound();
            }

            var lignes = await _unitOfWork.LigneLivraisons.GetLignesByMedicamentAsync(refMed);
            ViewBag.RefMed = refMed;
            return View(lignes);
        }

        private async Task<bool> LigneLivraisonExists(int id)
        {
            var ligne = await _unitOfWork.LigneLivraisons.GetByIdAsync(id);
            return ligne != null;
        }

        private async Task PopulateDropdowns(string selectedRefMed = null, string selectedNumLiv = null)
        {
            var medicaments = await _unitOfWork.Medicaments.GetAllAsync();
            var livraisons = await _unitOfWork.Livraisons.GetAllAsync();

            ViewBag.RefMed = new SelectList(medicaments, "Reference", "Description", selectedRefMed);
            ViewBag.NumLiv = new SelectList(livraisons, "Numero", "Numero", selectedNumLiv);
        }
    }
}

