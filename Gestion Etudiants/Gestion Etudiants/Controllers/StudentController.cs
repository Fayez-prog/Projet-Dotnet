using Gestion_Etudiants.Models;
using Gestion_Etudiants.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Etudiants.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISchoolRepository _schoolRepository;

        public StudentController(IStudentRepository studentRepository, ISchoolRepository schoolRepository)
        {
            _studentRepository = studentRepository;
            _schoolRepository = schoolRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var students = _studentRepository.GetAll();
            ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Create()
        {
            ViewBag.SchoolList = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View(new Student { BirthDate = DateTime.Today }); // Valeur par défaut
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StudentName,Age,BirthDate,SchoolID")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.Add(student);
                    TempData["SuccessMessage"] = "Étudiant créé avec succès";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erreur: {ex.Message}");
            }

            ViewBag.SchoolList = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName", student.SchoolID);
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName", student.SchoolID);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("StudentId,StudentName,Age,BirthDate,SchoolID")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _studentRepository.Edit(student);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName", student.SchoolID);
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student != null)
            {
                _studentRepository.Delete(student);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search(string name, int schoolid)
        {
            var result = _studentRepository.GetAll();

            if (!string.IsNullOrEmpty(name))
                result = _studentRepository.FindByName(name);
            else if (schoolid != 0)
                result = _studentRepository.GetStudentsBySchoolID(schoolid);

            ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
    }
}
