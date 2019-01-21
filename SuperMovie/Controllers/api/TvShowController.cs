using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SuperMovie.Dtos;
using SuperMovie.Models;

namespace SuperMovie.Controllers.Api
{

    public class TvShowController : ApiController
    {
        private ApplicationDbContext _context;

        public TvShowController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<TvShowDto> GetTvShow()
        {
            return _context.TvShows
                .Include(t => t.Genre)
                .ToList()
                .Select(Mapper.Map<TvShow, TvShowDto>);
        }

        public IHttpActionResult GetTvShow(int id)
        {
            var tvshow = _context.TvShows.SingleOrDefault(t => t.Id == id);

            if (tvshow == null)
                return NotFound();

            return Ok(Mapper.Map<TvShow, TvShowDto>(tvshow));
        }



        [HttpPost]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateTvShow(TvShowDto tvshowDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tvshow = Mapper.Map<TvShowDto, TvShow>(tvshowDto);
            _context.TvShows.Add(tvshow);
            _context.SaveChanges();

            tvshowDto.Id = tvshow.Id;
            return Created(new Uri(Request.RequestUri + "/" + tvshow.Id), tvshowDto);
        }

        [HttpPut]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateTvShow(int id, TvShowDto tvshowDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tvshowInDb = _context.TvShows.SingleOrDefault(t => t.Id == id);

            if (tvshowInDb == null)
                return NotFound();

            Mapper.Map(tvshowDto, tvshowInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteTvShow(int id)
        {
            var tvshowInDb = _context.TvShows.SingleOrDefault(t => t.Id == id);

            if (tvshowInDb == null)
                return NotFound();

            _context.TvShows.Remove(tvshowInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}