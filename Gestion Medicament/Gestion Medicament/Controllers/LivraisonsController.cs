using Gestion_Medicament.Entity.Interface;
using Gestion_Medicament.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Medicament.Controllers
{
    public class LivraisonsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LivraisonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Livraisons
        public async Task<IActionResult> Index()
        {
            var livraisons = await _unitOfWork.Livraisons.GetAllAsync();
            return View(livraisons);
        }

        // GET: Livraisons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livraison = await _unitOfWork.Livraisons.GetByIdAsync(id);
            if (livraison == null)
            {
                return NotFound();
            }

            // Charger les lignes de livraison associées
            livraison.Lignes = (ICollection<LigneLivraison>)await _unitOfWork.LigneLivraisons.GetLignesByLivraisonAsync(id);
            return View(livraison);
        }

        // GET: Livraisons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livraisons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,Fournisseur,DateLiv,Total")] Livraison livraison)
        {
            if (ModelState.IsValid)
            {
                livraison.DateLiv = DateTime.Now; // Date actuelle par défaut
                await _unitOfWork.Livraisons.AddAsync(livraison);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livraison);
        }

        // GET: Livraisons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livraison = await _unitOfWork.Livraisons.GetByIdAsync(id);
            if (livraison == null)
            {
                return NotFound();
            }
            return View(livraison);
        }

        // POST: Livraisons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Numero,Fournisseur,DateLiv,Total")] Livraison livraison)
        {
            if (id != livraison.Numero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.Livraisons.UpdateAsync(livraison);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livraison);
        }

        // GET: Livraisons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livraison = await _unitOfWork.Livraisons.GetByIdAsync(id);
            if (livraison == null)
            {
                return NotFound();
            }

            return View(livraison);
        }

        // POST: Livraisons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            // Supprimer d'abord les lignes associées
            var lignes = await _unitOfWork.LigneLivraisons.GetLignesByLivraisonAsync(id);
            foreach (var ligne in lignes)
            {
                await _unitOfWork.LigneLivraisons.DeleteAsync(ligne.RefMed); // Adaptez selon votre clé primaire
            }

            await _unitOfWork.Livraisons.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Livraisons/ByFournisseur
        public async Task<IActionResult> ByFournisseur(string fournisseur)
        {
            var livraisons = await _unitOfWork.Livraisons.GetLivraisonsByFournisseurAsync(fournisseur);
            ViewBag.Fournisseur = fournisseur;
            return View(livraisons);
        }

        // GET: Livraisons/Stats
        public async Task<IActionResult> Stats(DateTime? startDate, DateTime? endDate)
        {
            startDate ??= DateTime.Now.AddMonths(-1);
            endDate ??= DateTime.Now;

            var total = await _unitOfWork.Livraisons.GetTotalLivraisonsAsync(startDate, endDate);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.Total = total;

            return View();
        }
    }
}
