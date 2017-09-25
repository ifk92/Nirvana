using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using WebAppMVC.Models;
using WebAppMVC.ViewModels;
using System.Data.Entity;
using System.Collections.Generic;

namespace WebAppMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PostsController()
        {
            _context = new ApplicationDbContext();
        }



        // GET: Posts
        [Authorize]
        public ActionResult Create()
        {
            var viewmodel = new PostFormViewModel
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewmodel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostFormViewModel viewModel)
        {
            //tells you if any model errors have been added to ModelState
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);

            }

            var post = new Post
            {
                UtilisateurId = User.Identity.GetUserId(),
                Text = viewModel.Text,
                CategorieId = viewModel.Categorie,

            };

            _context.Posts.Add(post);
            _context.SaveChangesAsync();

            return RedirectToAction("Index","Home");

        }

        public ActionResult Index()
        {
            var allPosts = _context.Posts.Include(p => p.Utilisateur).ToList();
            int i;
            string strCurrentUserId = User.Identity.GetUserId();


            //Dictionary<int, Post> myPosts = new Dictionary<int, Post>();
            
            List<Post> myPosts = new List<Post>();

            for (i = 0; i < allPosts.Count; i++)
            {
                if (allPosts[i].UtilisateurId == strCurrentUserId)
                {
                    myPosts.Add(allPosts[i]);
                    //myPosts[i].UtilisateurId = allPosts[i].UtilisateurId;
                    //myPosts[i].Id = allPosts[i].Id;
                    //myPosts[i].Text = allPosts[i].Text;
                    //myPosts[i].Categorie = allPosts[i].Categorie;

                }
                


            }
            ViewData["myPosts"] = myPosts;

            return View(myPosts);
        }


        [Authorize]
        public ActionResult Delete()
        {

            var viewmodel = new PostFormViewModel();
            viewmodel.Text = "aaaB";

            return View(viewmodel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PostFormViewModel viewModel)
        {
            //tells you if any model errors have been added to ModelState
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Delete", viewModel);

            }

            var post = new Post
            {
                UtilisateurId = User.Identity.GetUserId(),
                Text = viewModel.Text,
                CategorieId = viewModel.Categorie,

            };

            _context.Entry(post).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");

        }

    }
}