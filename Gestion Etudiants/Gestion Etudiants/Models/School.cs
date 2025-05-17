using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Etudiants.Models
{
    public class School
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAdress { get; set; }
        [ValidateNever]
        public ICollection<Student> Students { get; set; }
    }
}
