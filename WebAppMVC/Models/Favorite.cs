using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class Favorite
    {
        public Post Post { get; set; }

        //l'utilisation ayant mis en favoris le post
        public ApplicationUser FavUser { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PostId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FavUserId { get; set; }


    }
}