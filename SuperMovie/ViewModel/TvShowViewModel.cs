using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using SuperMovie.Migrations;
using SuperMovie.Models;

namespace SuperMovie.ViewModels
{
    public class TvShowViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }


        public string PicUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }





        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Tv Show" : "New Tv show";
            }
        }

        public TvShowViewModel()
        {
            Id = 0;
        }

        public TvShowViewModel(TvShow tvshow)
        {
            Id = tvshow.Id;
            Name = tvshow.Name;
            ReleaseDate = tvshow.ReleaseDate;
            GenreId = tvshow.GenreId;
            PicUrl = tvshow.PicUrl;
            VideoUrl = tvshow.VideoUrl;

        }
    }
}