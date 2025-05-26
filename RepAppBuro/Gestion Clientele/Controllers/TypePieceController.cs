using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Clientele.Controllers
{
    public class TypePieceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypePieceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var types = await _unitOfWork.TypePieces.GetAllAsync();
            return View(types);
        }

        public async Task<IActionResult> Details(int id)
        {
            var type = await _unitOfWork.TypePieces.GetTypePieceWithPiecesRechargeAsync(id);
            if (type == null) return NotFound();
            return View(type);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypePiece typePiece)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.TypePieces.AddAsync(typePiece);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typePiece);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var type = await _unitOfWork.TypePieces.GetByIdAsync(id);
            if (type == null) return NotFound();
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TypePiece typePiece)
        {
            if (id != typePiece.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _unitOfWork.TypePieces.Update(typePiece);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typePiece);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var type = await _unitOfWork.TypePieces.GetByIdAsync(id);
            if (type == null) return NotFound();
            return View(type);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var type = await _unitOfWork.TypePieces.GetByIdAsync(id);
            _unitOfWork.TypePieces.Remove(type);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateTarif(int id, decimal newTarif)
        {
            var type = await _unitOfWork.TypePieces.GetByIdAsync(id);
            if (type == null) return NotFound();

            type.Tarif = newTarif;
            _unitOfWork.TypePieces.Update(type);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
