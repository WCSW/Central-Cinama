using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperMovie.Models
{
    public class TvShow
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Tv show Name !")]
        [StringLength(255)]
        public string Name { get; set; }


        public Genre Genre { get; set; }


        [Required(ErrorMessage = "Please Select Genre !")]
        public byte GenreId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        public string PicUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }
    }
}