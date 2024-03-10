using BookStore;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class GenreController : Controller
    {
        // GET: GenreController
        public ActionResult Index()
        {
            var genreList = BookStoreBasicFunctions.GetAllGenres();
            return View(genreList);
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genreToAdd)
        {
            try
            {
                BookStoreBookFunctions.AddGenre(genreToAdd);
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }


        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            var genre = BookStoreBasicFunctions.GetGenreById(id);
            return View(genre);
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genreToEdit)
        {
            try
            {
                BookStoreBookFunctions.EditGenre(genreToEdit);
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            var genre = BookStoreBasicFunctions.GetGenreById(id);
            return View(genre);
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Genre genre)
        {
            try
            {
                BookStoreBookFunctions.DeleteGenre(genre.GenreId);
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }
    }
}
