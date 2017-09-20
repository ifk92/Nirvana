using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;
using WebAppMVC.ViewModels;
using System.Data.Entity;
using System.Net;

namespace WebAppMVC.Controllers
{
    public class MyPostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MyPostsController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: MyPosts
        public ActionResult Index()
        {
            var allPosts = _context.Posts.Include(p => p.Utilisateur).ToList();
            int i;
            string strCurrentUserId = User.Identity.GetUserId();

            List<Post> myPosts = new List<Post>();

            for (i = 0; i < allPosts.Count; i++)
            {
                if (allPosts[i].UtilisateurId == strCurrentUserId)
                {
                    myPosts.Add(allPosts[i]);
                }
                
            }
           
            return View(myPosts);
        }

        // GET: MyPosts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyPosts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPosts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyPosts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            var idt = Request.QueryString["id"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post pst = _context.Posts.Find(id);
            if (pst == null)
            {
                return HttpNotFound();
            }
            return View(pst);
        }

        // POST: MyPosts/Delete/5
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            try
            {
                Post pst = _context.Posts.Find(id);
                _context.Posts.Remove(pst);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
