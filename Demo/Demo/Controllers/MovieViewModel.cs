using System;

namespace Demo.Controllers
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Genres { get; set; }

        public MovieViewModel()
        {
            
        }
        private MovieViewModel(string title, string description, string[] genres)
        {
            Title = title;
            Description = description;
            Genres = genres;
        }

        public static MovieViewModel Create(string title, string description, string[] genres)
        {
            return new MovieViewModel(title, description, genres);
        }

        public bool IsMatch(string term)
        {
            return Title.ToLower().Contains(term.ToLower()) || (Description ?? "").ToLower().Contains(term.ToLower());
        }
    }
}