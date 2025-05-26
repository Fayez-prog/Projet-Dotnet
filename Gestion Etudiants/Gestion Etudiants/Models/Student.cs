using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestion_Etudiants.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Le nom de l'étudiant est obligatoire")]
        [Display(Name = "Nom de l'étudiant")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "L'âge est obligatoire")]
        [Range(1, 100, ErrorMessage = "L'âge doit être entre 1 et 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "L'école est obligatoire")]
        [Display(Name = "École")]
        public int SchoolID { get; set; }

        [ForeignKey("SchoolID")]
        [ValidateNever] // Important pour éviter la validation du champ de navigation
        public virtual School School { get; set; }
    }
}
