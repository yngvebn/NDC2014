using System;

namespace Demo.Controllers
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public MovieViewModel()
        {
            
        }
        private MovieViewModel(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public static MovieViewModel Create(string title, string description)
        {
            return new MovieViewModel(title, description);
        }

        public bool IsMatch(string term)
        {
            return Title.ToLower().Contains(term.ToLower()) || (Description ?? "").ToLower().Contains(term.ToLower());
        }
    }
}