using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeWheel.Models;

namespace FreeWheel.Data
{
  public static class IntialiseDB
  {
    public static void Intialise(MovieContext context)
    {
      context.Database.EnsureCreated();

      if (context.Users.Any())
      {
        return;
      }

      var users = new User[]
      {
        new User{UserName="Andy", Password="a"},
        new User{UserName="Ben", Password="a"},
        new User{UserName="Hannah", Password="a"},
        new User{UserName="Paul", Password="a"},
        new User{UserName="Michela", Password="a"}
      };

      foreach (User u in users)
      {
        context.Users.Add(u);
      }
      context.SaveChanges();

      var movies = new Movie[]
      {
        new Movie{Title="Guardians Of The Galaxy", Genre=Genre.Action, YearOfRelease=new DateTime(2014, 7, 31)},
        new Movie{Title="What We Do In The Shadows", Genre=Genre.Comedy, YearOfRelease=new DateTime(2014, 11, 24)},
        new Movie{Title="Deadpool", Genre=Genre.Action, YearOfRelease=new DateTime(2016, 2, 10)},
        new Movie{Title="Last House On The Left", Genre=Genre.Thriller, YearOfRelease=new DateTime(1972, 8, 30)},
        new Movie{Title="The Shawshank Redemption", Genre=Genre.Drama, YearOfRelease=new DateTime(1994, 2, 17)},
        new Movie{Title="City of God", Genre=Genre.Drama, YearOfRelease=new DateTime(2003, 1, 3)},
        new Movie{Title="Amélie", Genre=Genre.Romance, YearOfRelease=new DateTime(2001, 10, 5)},
        new Movie{Title="Groundhog Day", Genre=Genre.Comedy, YearOfRelease=new DateTime(1993, 5, 7)},
        new Movie{Title="The Shining", Genre=Genre.Horror, YearOfRelease=new DateTime(1980, 10, 5)},
        new Movie{Title="Black Panther", Genre=Genre.Action, YearOfRelease=new DateTime(2018, 2, 13)},
      };

      foreach (Movie m in movies)
      {
        context.Movies.Add(m);
      }
      context.SaveChanges();

      var ratings = new Rating[]
      {
         new Rating{UserUID=1, MovieUID=1, MovieRating=5 },
         new Rating{UserUID=1, MovieUID=2, MovieRating=4 },
         new Rating{UserUID=1, MovieUID=3, MovieRating=5 },
         new Rating{UserUID=1, MovieUID=6, MovieRating=3 },
         new Rating{UserUID=1, MovieUID=8, MovieRating=2 },
         new Rating{UserUID=2, MovieUID=1, MovieRating=4 },
         new Rating{UserUID=2, MovieUID=2, MovieRating=2 },
         new Rating{UserUID=2, MovieUID=6, MovieRating=1 },
         new Rating{UserUID=2, MovieUID=9, MovieRating=4 },
         new Rating{UserUID=2, MovieUID=10, MovieRating=5 },
         new Rating{UserUID=3, MovieUID=1, MovieRating=1 },
         new Rating{UserUID=3, MovieUID=6, MovieRating=2 },
         new Rating{UserUID=3, MovieUID=8, MovieRating=4 },
         new Rating{UserUID=3, MovieUID=9, MovieRating=3 },
         new Rating{UserUID=4, MovieUID=3, MovieRating=2 },
         new Rating{UserUID=4, MovieUID=4, MovieRating=3 },
         new Rating{UserUID=5, MovieUID=3, MovieRating=4 },
         new Rating{UserUID=5, MovieUID=4, MovieRating=5 },
         new Rating{UserUID=5, MovieUID=7, MovieRating=3 },
      };

      foreach (Rating r in ratings)
      {
        context.Ratings.Add(r);
      }
      context.SaveChanges();
    }

  }
}
