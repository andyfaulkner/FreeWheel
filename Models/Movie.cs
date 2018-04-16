using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeWheel.Models
{
  public enum Genre
  {
    Comedy,
    Action,
    Horror,
    Thriller,
    Romance,
    Drama
  }
  public class Movie
  {
    [Key]
    public int UID { get; set; }
    public string Title { get; set; }
    public DateTime YearOfRelease { get; set; }
    public Genre? Genre { get; set; }

    public ICollection<Rating> Ratings { get; set; }

    public int GetAverageRating()
    {
      int avg = 0;
      if (Ratings != null && Ratings.Count > 0)
      {
        var average = Ratings.Sum(r => r.MovieRating);
        avg = average / Ratings.Count;
      }
      return avg;
    }
  }
}
