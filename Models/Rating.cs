using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeWheel.Models
{
  public class Rating
  {
    [Key]
    public int UID { get; set; }
    public int MovieUID { get; set; }
    public int UserUID { get; set; }
    public int MovieRating { get; set; }

    public User User { get; set; }
    public Movie Movie { get; set; }
  }
}
