using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Web.Razor;
using SuperMovie.Models;
using SuperMovie.ViewModel;
using SuperMovie.ViewModels;

namespace SuperMovie.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {


            if (User.IsInRole(RoleName.CanManageMovies))
                return View("AdminMovieIndex");
            return View(await _context.Movies.Include(m => m.Genre).ToListAsync());
        }





        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }




        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {

                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm" , viewModel);
            }


            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.PicUrl = movie.PicUrl;
                movieInDb.VideoUrl = movie.VideoUrl;
                movieInDb.Description = movie.Description;
            }

            
                _context.SaveChanges();
            

            return RedirectToAction("Index","Movies");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();

            }


            var viewModel = new MovieFormViewModel(movie)
            {
               
                Genres =  _context.Genres.ToList()

            };

            return View("MovieForm", viewModel);
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {

            var genres = _context.Genres.ToList();




            var viewModel = new MovieFormViewModel
            {
                
                Genres = genres
            };



            return View("MovieForm" ,viewModel);
        }

      
    }
}