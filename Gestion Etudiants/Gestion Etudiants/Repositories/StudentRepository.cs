using Gestion_Etudiants.Data;
using Gestion_Etudiants.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gestion_Etudiants.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public IList<Student> GetAll()
        {
            return _context.Students
                .OrderBy(s => s.StudentName)
                .Include(s => s.School)
                .ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students
                .Include(s => s.School)
                .FirstOrDefault(s => s.StudentId == id);
        }

        public void Add(Student student)
        {
            try
            {
                // Validation renforcée
                if (student == null)
                    throw new ArgumentNullException(nameof(student));

                if (student.SchoolID <= 0)
                    throw new ArgumentException("ID d'école invalide");

                if (!_context.Schools.Any(s => s.SchoolID == student.SchoolID))
                    throw new InvalidOperationException("L'école spécifiée n'existe pas");

                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log l'erreur complète
                Console.WriteLine($"ERREUR DB: {ex.InnerException?.Message}");
                throw new Exception("Erreur d'enregistrement dans la base de données", ex);
            }
        }

        public void Edit(Student student)
        {
            var existingStudent = _context.Students.Find(student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.StudentName = student.StudentName;
                existingStudent.Age = student.Age;
                existingStudent.BirthDate = student.BirthDate;
                existingStudent.SchoolID = student.SchoolID;
                _context.SaveChanges();
            }
        }

        public void Delete(Student student)
        {
            var studentToDelete = _context.Students.Find(student.StudentId);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }
        }

        public IList<Student> GetStudentsBySchoolID(int schoolId)
        {
            return _context.Students
                .Where(s => s.SchoolID == schoolId)
                .OrderBy(s => s.StudentName)
                .Include(s => s.School)
                .ToList();
        }

        public IList<Student> FindByName(string name)
        {
            return _context.Students
                .Where(s => s.StudentName.Contains(name))
                .Include(s => s.School)
                .ToList();
        }
    }
}
