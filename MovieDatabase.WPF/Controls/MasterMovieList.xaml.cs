﻿using MovieDatabase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieDatabase.WPF.Controls
{
    /// <summary>
    /// Interaction logic for MasterMovieList.xaml
    /// </summary>
    public partial class MasterMovieList : UserControl
    {
        public MasterMovieList()
        {
            InitializeComponent();

            List<Movie> movie = new List<Movie>();
            movie.Add(new Movie() { Id = 1, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = new Producer() { Id = 1, Name = "Peter Steele", DOB = new DateTime(1990, 05, 01, 12, 00, 00), Biography = "This is a biography" }, Studio = new Studio() {Id = 1, Name = "Fairy Tale Media", Phone = 55555, Email = "petersteele111@example.com", Description = "Studio Description", Website = "https://www.pbsteele.com", Address = "6847 cram road", City = "Williamsburg", State = "MI", Zipcode = 49690 }, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 2, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 3, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 4, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 5, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 6, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 7, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 8, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 9, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });
            movie.Add(new Movie() { Id = 10, Title = "Harry Potter", Description = "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.", IMDBLink = "https://www.imdb.com", Producer = null, Studio = null, ReleaseDate = new DateTime(2020 - 12 - 25), Runtime = 180 });

            LVMovies.ItemsSource = movie;
            
        }
    }
}
