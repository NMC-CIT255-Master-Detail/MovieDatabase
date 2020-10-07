using MovieDatabase.Domain.Models;
using System;
using System.Collections.Generic;

namespace MovieDatabase.Domain.Seed_Data
{
    public class SeedData
    {
        public static List<Movie> GetAllMovies()
        {
            return new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Title = "Harry Potter",
                    Description =
                        "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.",
                    IMDBLink = "https://www.imdb.com",
                    Producer = new Producer()
                    {
                        Id = 1,
                        Name = "Peter Steele",
                        DOB = new DateTime(1990, 05, 01, 12, 00, 00),
                        Biography = "This is a biography"
                    },
                    Studio = new Studio()
                    {
                        Id = 1,
                        Name = "Fairy Tale Media",
                        Phone = 55555,
                        Email = "petersteele111@example.com",
                        Description = "Studio Description",
                        Website = "https://www.pbsteele.com",
                        Address = "6847 cram road",
                        City = "Williamsburg",
                        State = "MI",
                        Zipcode = 49690
                    },
                    ReleaseDate = new DateTime(1997, 12, 25, 12, 00, 0),
                    Runtime = 180
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Harry Potter and the Goblet of Fire",
                    Description =
                        "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.",
                    IMDBLink = "https://www.imdb.com",
                    Producer = new Producer()
                    {
                        Id = 2,
                        Name = "Mark Zones",
                        DOB = new DateTime(1999, 05, 01, 12, 00, 00),
                        Biography = "This is a biography"
                    },
                    Studio = new Studio()
                    {
                        Id = 2,
                        Name = "Dont Care Media",
                        Phone = 55555,
                        Email = "petersteele111@example.com",
                        Description = "Studio Description",
                        Website = "https://www.pbsteele.com",
                        Address = "6847 cram road",
                        City = "Williamsburg",
                        State = "MI",
                        Zipcode = 49690
                    },
                    ReleaseDate = new DateTime(2002, 12, 25, 12, 00, 0),
                    Runtime = 60
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Harry Potter and the Sorcers Stone",
                    Description =
                        "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.",
                    IMDBLink = "https://www.imdb.com",
                    Producer = new Producer()
                    {
                        Id = 3,
                        Name = "IHatePickingNames SoMuch",
                        DOB = new DateTime(1980, 05, 01, 12, 00, 00),
                        Biography = "This is a biography"
                    },
                    Studio = new Studio()
                    {
                        Id = 3,
                        Name = "Seed Data is meh",
                        Phone = 55555,
                        Email = "petersteele111@example.com",
                        Description = "Studio Description",
                        Website = "https://www.pbsteele.com",
                        Address = "6847 cram road",
                        City = "Williamsburg",
                        State = "MI",
                        Zipcode = 49690
                    },
                    ReleaseDate = new DateTime(1970, 12, 25, 12, 00, 0),
                    Runtime = 240
                },
                new Movie()
                {
                    Id = 4,
                    Title = "Harry Potter and the Half Blood Prince",
                    Description =
                        "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.",
                    IMDBLink = "https://www.imdb.com",
                    Producer = new Producer()
                    {
                        Id = 1,
                        Name = "Peter Steele",
                        DOB = new DateTime(1990, 05, 01, 12, 00, 00),
                        Biography = "This is a biography"
                    },
                    Studio = new Studio()
                    {
                        Id = 1,
                        Name = "Fairy Tale Media",
                        Phone = 55555,
                        Email = "petersteele111@example.com",
                        Description = "Studio Description",
                        Website = "https://www.pbsteele.com",
                        Address = "6847 cram road",
                        City = "Williamsburg",
                        State = "MI",
                        Zipcode = 49690
                    },
                    ReleaseDate = new DateTime(2020, 12, 25, 12, 00, 0),
                    Runtime = 84
                },
                new Movie()
                {
                    Id = 5,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Description =
                        "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.",
                    IMDBLink = "https://www.imdb.com",
                    Producer = new Producer()
                    {
                        Id = 1,
                        Name = "Peter Steele",
                        DOB = new DateTime(1990, 05, 01, 12, 00, 00),
                        Biography = "This is a biography"
                    },
                    Studio = new Studio()
                    {
                        Id = 1,
                        Name = "Fairy Tale Media",
                        Phone = 55555,
                        Email = "petersteele111@example.com",
                        Description = "Studio Description",
                        Website = "https://www.pbsteele.com",
                        Address = "6847 cram road",
                        City = "Williamsburg",
                        State = "MI",
                        Zipcode = 49690
                    },
                    ReleaseDate = new DateTime(2015, 12, 25, 12, 00, 0),
                    Runtime = 120
                },
                new Movie()
                {
                    Id = 6,
                    Title = "Harry Potter and the Prizoner of Azkaban",
                    Description =
                        "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.",
                    IMDBLink = "https://www.imdb.com",
                    Producer = new Producer()
                    {
                        Id = 4,
                        Name = "Alyssa Hershel",
                        DOB = new DateTime(1990, 05, 01, 12, 00, 00),
                        Biography = "This is a biography"
                    },
                    Studio = new Studio()
                    {
                        Id = 4,
                        Name = "This is torture Media",
                        Phone = 55555,
                        Email = "petersteele111@example.com",
                        Description = "Studio Description",
                        Website = "https://www.pbsteele.com",
                        Address = "6847 cram road",
                        City = "Williamsburg",
                        State = "MI",
                        Zipcode = 49690
                    },
                    ReleaseDate = new DateTime(2020, 12, 25, 12, 00, 0),
                    Runtime = 150
                },
                new Movie()
                {
                    Id = 7,
                    Title = "Harry Potter and the Order of the Pheonix",
                    Description =
                        "Harry Potter is a great movie from the early to late 2000's that follows a wizard named Harry and his journey through school at Hogwarts and beyond.",
                    IMDBLink = "https://www.imdb.com",
                    Producer = new Producer()
                    {
                        Id = 1,
                        Name = "Peter Steele",
                        DOB = new DateTime(1990, 05, 01, 12, 00, 00),
                        Biography = "This is a biography"
                    },
                    Studio = new Studio()
                    {
                        Id = 1,
                        Name = "Fairy Tale Media",
                        Phone = 55555,
                        Email = "petersteele111@example.com",
                        Description = "Studio Description",
                        Website = "https://www.pbsteele.com",
                        Address = "6847 cram road",
                        City = "Williamsburg",
                        State = "MI",
                        Zipcode = 49690
                    },
                    ReleaseDate = new DateTime(1994, 12, 25, 12, 00, 0),
                    Runtime = 15
                },
                new Movie()
                {
                    Id = 8,
                    Title = "Spider-Man: Far from Home",
                    Description =
                        "Spider-Man: Far From Home is a 2019 American superhero film based on the Marvel Comics character Spider-Man, co-produced by Columbia Pictures and Marvel Studios, and distributed by Sony Pictures Releasing. It is the sequel to Spider-Man: Homecoming (2017) and the 23rd film in the Marvel Cinematic Universe (MCU).",
                    IMDBLink = "https://www.imdb.com",
                    Producer = new Producer()
                    {
                        Id = 1,
                        Name = "Kevin Feige",
                        DOB = new DateTime(1973, 05, 01, 12, 00, 00),
                        Biography = "This is a biography"
                    },
                    Studio = new Studio()
                    {
                        Id = 1,
                        Name = "Sony Pictures",
                        Phone = 55555,
                        Email = "colecrain1234@example.com",
                        Description = "Studio Description",
                        Address = "10202 Washington Blvd ",
                        City = "Culver City",
                        State = "CA",
                        Zipcode = 90232
                    },
                    ReleaseDate = new DateTime(2019, 2, 25, 12, 00, 0),
                    Runtime = 129
                }
            };
        }
    }
}