using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SuperMovie.Models;

namespace SuperMovie.Dtos
{
    public class TvShowDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public Genre Genre { get; set; }


        [Required]
        public byte GenreId { get; set; }

        
        public DateTime DateAdded { get; set; }


        
        public DateTime ReleaseDate { get; set; }


        public string PicUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }
    }
}