using Gestion_Clientele.Entity.Interface;
using Gestion_Clientele.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Clientele.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var clients = await _unitOfWork.Clients.GetAllAsync();
            return View(clients);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = await _unitOfWork.Clients.GetClientWithAppareilsAsync(id);
            var clients = await _unitOfWork.Clients.GetClientWithDemandesReparationAsync(id);
            if (client == null & clients == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Adresse,NumTel")] Client client)
        {
            if (!ModelState.IsValid)
            {
                // Log des erreurs (ex. avec ILogger)
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(client);
            }

            await _unitOfWork.Clients.AddAsync(client);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Adresse,NumTel")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Clients.Update(client);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            _unitOfWork.Clients.Remove(client);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
