using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebapi {
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; } //DateTime

        public int GenreId { get; set; }

        public int DirectorId { get; set; }

        //public string[] Actors {get; set;}

        public double price {get; set;}

    }

}

