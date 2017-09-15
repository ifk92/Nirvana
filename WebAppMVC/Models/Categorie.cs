using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Categorie
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}