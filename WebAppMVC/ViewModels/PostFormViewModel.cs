using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppMVC.Models;

namespace WebAppMVC.ViewModels
{
    public class PostFormViewModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public byte Categorie { get; set; }

        public IEnumerable<Categorie> Categories { get; set; }
    }
}