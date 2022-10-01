namespace MovieWebapi {
    public class Movie
    {
        // public Movie(int id, string title, int year, int genreId, string director, double price) 
        // {
        //     this.Id = id;
        //     this.Title = title;
        //     this.Year = year;
        //     this.GenreId = genreId;
        //     this.Director = director;
        //     this.price = price;
        // }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; } //DateTime

        public int GenreId { get; set; }

        public int DirectorId { get; set; }

        //public string[] Actors {get; set;}

        public double price {get; set;}

    }

}

