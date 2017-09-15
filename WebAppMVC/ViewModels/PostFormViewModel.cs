using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMVC.Models;

namespace WebAppMVC.ViewModels
{
    public class PostFormViewModel
    {
        public string Text { get; set; }

        public byte Categorie { get; set; }

        public IEnumerable<Categorie> Categories { get; set; }
    }
}