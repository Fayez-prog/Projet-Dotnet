using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_Clientele.Controllers
{
    public class PieceRechargeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PieceRechargeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var pieces = await _unitOfWork.PiecesRecharge.GetPiecesWithTypePieceAsync();
            return View(pieces);
        }

        public async Task<IActionResult> Details(int id)
        {
            var piece = await _unitOfWork.PiecesRecharge.GetPieceWithTypePieceAsync(id);
            if (piece == null) return NotFound();
            return View(piece);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.TypePieces = new SelectList(await _unitOfWork.TypePieces.GetAllAsync(), "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PieceRecharge piece)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.PiecesRecharge.AddAsync(piece);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TypePieces = new SelectList(await _unitOfWork.TypePieces.GetAllAsync(), "Id", "Type", piece.TypePieceId);
            return View(piece);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var piece = await _unitOfWork.PiecesRecharge.GetByIdAsync(id);
            if (piece == null) return NotFound();
            ViewBag.TypePieces = new SelectList(await _unitOfWork.TypePieces.GetAllAsync(), "Id", "Type", piece.TypePieceId);
            return View(piece);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PieceRecharge piece)
        {
            if (id != piece.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _unitOfWork.PiecesRecharge.Update(piece);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TypePieces = new SelectList(await _unitOfWork.TypePieces.GetAllAsync(), "Id", "Type", piece.TypePieceId);
            return View(piece);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var piece = await _unitOfWork.PiecesRecharge.GetByIdAsync(id);
            if (piece == null) return NotFound();
            return View(piece);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piece = await _unitOfWork.PiecesRecharge.GetByIdAsync(id);
            _unitOfWork.PiecesRecharge.Remove(piece);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LowStock()
        {
            var pieces = await _unitOfWork.PiecesRecharge.GetPiecesLowStockAsync(5); // Seuil de 5 pièces
            return View(pieces);
        }

        public async Task<IActionResult> Restock(int id, int quantity)
        {
            var piece = await _unitOfWork.PiecesRecharge.GetByIdAsync(id);
            if (piece == null) return NotFound();

            piece.Quantite += quantity;
            _unitOfWork.PiecesRecharge.Update(piece);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
