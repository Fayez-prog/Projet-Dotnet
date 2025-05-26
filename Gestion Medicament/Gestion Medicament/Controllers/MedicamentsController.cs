using Gestion_Medicament.Entity.Interface;
using Gestion_Medicament.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Medicament.Controllers
{
    public class MedicamentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicamentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Medicaments
        public async Task<IActionResult> Index()
        {
            var medicaments = await _unitOfWork.Medicaments.GetAllAsync();
            return View(medicaments);
        }

        // GET: Medicaments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _unitOfWork.Medicaments.GetByIdAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }

        // GET: Medicaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicaments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Reference,Description,Quantite,Prix")] Medicament medicament)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Medicaments.AddAsync(medicament);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicament);
        }

        // GET: Medicaments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _unitOfWork.Medicaments.GetByIdAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }
            return View(medicament);
        }

        // POST: Medicaments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Reference,Description,Quantite,Prix")] Medicament medicament)
        {
            if (id != medicament.Reference)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.Medicaments.UpdateAsync(medicament);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicament);
        }

        // GET: Medicaments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _unitOfWork.Medicaments.GetByIdAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }

        // POST: Medicaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _unitOfWork.Medicaments.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Medicaments/LowStock
        public async Task<IActionResult> LowStock(int seuil = 10)
        {
            var medicaments = await _unitOfWork.Medicaments.GetMedicamentsLowStockAsync(seuil);
            ViewBag.Seuil = seuil;
            return View(medicaments);
        }

        // GET: Medicaments/StockValue
        public async Task<IActionResult> StockValue()
        {
            var totalValue = await _unitOfWork.Medicaments.GetTotalStockValueAsync();
            return View(totalValue);
        }
    }
}
