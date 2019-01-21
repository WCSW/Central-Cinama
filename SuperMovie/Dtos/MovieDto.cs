using System;
using System.ComponentModel.DataAnnotations;
using SuperMovie.Dtos;

namespace SuperMovie.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 35)]
        public byte NumberInStock { get; set; }

        public string PicUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }
    }
}