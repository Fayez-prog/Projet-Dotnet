using DinkToPdf;
using DinkToPdf.Contracts;
using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Extension;
using Gestion_Clientele.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_Clientele.Controllers
{
    public class FactureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter _converter;

        public FactureController(IUnitOfWork unitOfWork, IConverter converter)
        {
            _unitOfWork = unitOfWork;
            _converter = converter;
        }

        public async Task<IActionResult> Index()
        {
            var factures = await _unitOfWork.Factures.GetFactureWithReparationAsync();
            return View(factures);
        }

        public async Task<IActionResult> Details(int id)
        {
            var facture = await _unitOfWork.Factures.GetFactureWithReparationAsync(id);
            if (facture == null) return NotFound();
            return View(facture);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Reparations = new SelectList(await _unitOfWork.Reparations.GetAllAsync(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Facture facture)
        {
            if (ModelState.IsValid)
            {
                // Check if an invoice already exists for this repair
                var existingInvoice = await _unitOfWork.Factures
                    .FindAsync(f => f.ReparationId == facture.ReparationId);

                if (existingInvoice.Any())
                {
                    ModelState.AddModelError("ReparationId", "Une facture existe déjà pour cette réparation.");
                    ViewBag.Reparations = new SelectList(await _unitOfWork.Reparations.GetAllAsync(), "Id", "Id", facture.ReparationId);
                    return View(facture);
                }

                facture.Numero = await _unitOfWork.Factures.GenerateNextInvoiceNumberAsync();
                facture.Date = DateTime.Now;

                await _unitOfWork.Factures.AddAsync(facture);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Reparations = new SelectList(await _unitOfWork.Reparations.GetAllAsync(), "Id", "Id", facture.ReparationId);
            return View(facture);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var facture = await _unitOfWork.Factures.GetByIdAsync(id);
            if (facture == null) return NotFound();
            ViewBag.Reparations = new SelectList(await _unitOfWork.Reparations.GetAllAsync(), "Id", "Id", facture.ReparationId);
            return View(facture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Facture facture)
        {
            if (id != facture.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _unitOfWork.Factures.Update(facture);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Reparations = new SelectList(await _unitOfWork.Reparations.GetAllAsync(), "Id", "Id", facture.ReparationId);
            return View(facture);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var facture = await _unitOfWork.Factures.GetByIdAsync(id);
            if (facture == null) return NotFound();
            return View(facture);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facture = await _unitOfWork.Factures.GetByIdAsync(id);
            _unitOfWork.Factures.Remove(facture);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GeneratePdf(int id)
        {
            var facture = await _unitOfWork.Factures.GetFactureWithReparationAsync(id);
            if (facture == null) return NotFound();

            // Rendre la vue en HTML
            var htmlContent = await this.RenderViewAsync("PrintFacture", facture);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                DocumentTitle = $"Facture_{facture.Numero}"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontSize = 9, Center = $"Facture {facture.Numero}", Line = true }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", $"Facture_{facture.Numero}.pdf");
        }
    }
}

