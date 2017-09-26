using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using WebAppMVC.Models;
using WebAppMVC.ViewModels;

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
                Date = viewModel.CurrentTime(),
                CategorieId = viewModel.Categorie,

            };

            _context.Posts.Add(post);

            _context.SaveChangesAsync();

            return RedirectToAction("Index","Home");


        }

    }
}