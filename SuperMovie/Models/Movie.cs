using System;
using System.ComponentModel.DataAnnotations;

namespace SuperMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Name !")]
        [StringLength(255)]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }


        [Required(ErrorMessage = "Please Select Genre !")]
        public byte GenreId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Number In Stock")]
        [Range(1,50)]
        public byte NumberInStock { get; set; }

        public string  PicUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }
    }
}