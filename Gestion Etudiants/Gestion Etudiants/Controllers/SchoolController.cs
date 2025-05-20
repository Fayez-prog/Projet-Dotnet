using Gestion_Etudiants.Models;
using Gestion_Etudiants.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Etudiants.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class SchoolController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var schools = _schoolRepository.GetAll();

            // Préparer les données pour la vue
            var viewBagData = new Dictionary<int, int>();
            var ageAverages = new Dictionary<int, double>();

            foreach (var school in schools)
            {
                viewBagData[school.SchoolID] = _schoolRepository.StudentCount(school.SchoolID);
                ageAverages[school.SchoolID] = _schoolRepository.StudentAgeAverage(school.SchoolID);
            }

            ViewBag.StudentCount = viewBagData;
            ViewBag.AgeAverage = ageAverages;

            return View(schools);
        }

        public IActionResult Details(int id)
        {
            var school = _schoolRepository.GetById(id);
            if (school == null)
            {
                return NotFound();
            }

            ViewBag.StudentCount = _schoolRepository.StudentCount(id);
            ViewBag.AverageAge = _schoolRepository.StudentAgeAverage(id);

            return View(school);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SchoolName,SchoolAdress")] School school)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // La collection Students sera null, ce qui est correct
                    _schoolRepository.Add(school);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erreur lors de la création : " + ex.Message);
                }
            }
            return View(school);
        }

        public IActionResult Edit(int id)
        {
            var school = _schoolRepository.GetById(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SchoolID,SchoolName,SchoolAdress")] School school)
        {
            if (id != school.SchoolID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _schoolRepository.Edit(school);
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        public IActionResult Delete(int id)
        {
            var school = _schoolRepository.GetById(id);
            if (school == null)
            {
                return NotFound();
            }

            ViewBag.StudentCount = _schoolRepository.StudentCount(id);

            return View(school);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var school = _schoolRepository.GetById(id);
            if (school != null)
            {
                _schoolRepository.Delete(school);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
