using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FreeWheel.Models
{
  public class User
  {
    [Key]
    public int UID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public ICollection<Rating> Ratings { get; set; }
  }
}
