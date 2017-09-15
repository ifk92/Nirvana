using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebAppMVC.Models
{
    public class Post
    {
        public int Id { get; set; }

        public ApplicationUser Utilisateur { get; set; }


        [Required]
        public string UtilisateurId { get; set; }

        [Required]
        [StringLength(255)]
        public string Text { get; set; }

        public Categorie Categorie { get; set; }

        [Required]
        public byte CategorieId { get; set; }

    }
}