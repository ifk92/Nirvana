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

        public DateTime Date { get; set; }

        public DateTime GetDiffTime()
        {
            TimeSpan ts = DateTime.Now - Date;
            DateTime diff = new DateTime(0, 0, 0);
            diff = diff + ts;

            return diff;
        }

        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }





        public IEnumerable<Categorie> Categories { get; set; }
    }
}