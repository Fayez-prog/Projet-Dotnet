using Gestion_Etudiants.Data;
using Gestion_Etudiants.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Etudiants.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly StudentContext _context;

        public SchoolRepository(StudentContext context)
        {
            _context = context;
        }

        public IList<School> GetAll()
        {
            return _context.Schools.OrderBy(s => s.SchoolName).ToList();
        }

        public School GetById(int id)
        {
            return _context.Schools.Find(id);
        }

        public void Add(School school)
        {
            try
            {
                _context.Schools.Add(school);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log l'erreur
                Console.WriteLine($"Erreur lors de l'ajout : {ex.InnerException?.Message}");
                throw; // Rejeter l'exception pour qu'elle soit gérée par le contrôleur
            }
        }

        public void Edit(School school)
        {
            var existingSchool = _context.Schools.Find(school.SchoolID);
            if (existingSchool != null)
            {
                existingSchool.SchoolName = school.SchoolName;
                existingSchool.SchoolAdress = school.SchoolAdress;
                _context.SaveChanges();
            }
        }

        public void Delete(School school)
        {
            var schoolToDelete = _context.Schools.Find(school.SchoolID);
            if (schoolToDelete != null)
            {
                _context.Schools.Remove(schoolToDelete);
                _context.SaveChanges();
            }
        }

        public double StudentAgeAverage(int schoolId)
        {
            var hasStudents = _context.Students.Any(s => s.SchoolID == schoolId);

            return hasStudents ?
                _context.Students
                    .Where(s => s.SchoolID == schoolId)
                    .Average(s => s.Age) :
                0;
        }

        public int StudentCount(int schoolId)
        {
            return _context.Students.Count(s => s.SchoolID == schoolId);
        }
    }
}
