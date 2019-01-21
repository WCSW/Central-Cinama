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
    public class TvShowController : Controller
    {
        private ApplicationDbContext _context;

        public TvShowController()
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
             return View("AdminTvShowIndex");
             return View(await _context.TvShows.Include(t => t.Genre).ToListAsync());
        }





        public ActionResult Details(int id)
        {
            var tvshow = _context.TvShows.Include(t => t.Genre).SingleOrDefault(t => t.Id == id);

            if (tvshow == null)
                return HttpNotFound();

            return View(tvshow);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(TvShow tvshow)
        {
            if (!ModelState.IsValid)
            {

                var viewModel = new TvShowViewModel(tvshow)
                {

                    Genres = _context.Genres.ToList()
                };
                return View("TvShowForm", viewModel);
            }


            if (tvshow.Id == 0)
            {
                tvshow.DateAdded = DateTime.Now;
                _context.TvShows.Add(tvshow);
            }
            else
            {
                var tvshowInDb = _context.TvShows.Single(t => t.Id == tvshow.Id);
                tvshowInDb.Name = tvshow.Name;
                tvshowInDb.GenreId = tvshow.GenreId;
                tvshowInDb.ReleaseDate = tvshow.ReleaseDate;
                tvshowInDb.PicUrl = tvshow.PicUrl;
                tvshowInDb.VideoUrl = tvshow.VideoUrl;
                tvshowInDb.Description = tvshow.Description;
            }


            _context.SaveChanges();


            return RedirectToAction("Index", "TvShow");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var tvshow = _context.TvShows.SingleOrDefault(t=> t.Id == id);
            if (tvshow == null)
            {
                return HttpNotFound();

            }


            var viewModel = new TvShowViewModel(tvshow)
            {

                Genres = _context.Genres.ToList()

            };

            return View("TvShowForm", viewModel);
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {

            var genres = _context.Genres.ToList();




            var viewModel = new TvShowViewModel()
            {

                Genres = genres
            };



            return View("TvShowForm", viewModel);
        }


    }
}