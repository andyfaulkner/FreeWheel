using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreeWheel.Data;
using FreeWheel.Models;

namespace FreeWheel.Controllers
{
  public class MoviesController : Controller
  {
    private readonly MovieContext _context;

    public MoviesController(MovieContext context)
    {
      _context = context;
    }

    // GET: Movies
    public async Task<IActionResult> Index()
    {
      var movies = _context.Movies;
      foreach (Movie m in movies)
      {
        if (m.Ratings == null)
        {
          await _context.Ratings.ForEachAsync(r =>
          {
            if (r.MovieUID == m.UID)
            {
              m.Ratings.Add(r);
            }
          });
        }
      }
     
      return View(await movies.ToListAsync());
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var movie = await _context.Movies
          .SingleOrDefaultAsync(m => m.UID == id);
      if (movie == null)
      {
        return NotFound();
      }
      
      return View(movie);
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Movies/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("UID,Title,YearOfRelease,Genre")] Movie movie)
    {
      if (ModelState.IsValid)
      {
        _context.Add(movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(movie);
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var movie = await _context.Movies.SingleOrDefaultAsync(m => m.UID == id);
      if (movie == null)
      {
        return NotFound();
      }
      return View(movie);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("UID,Title,YearOfRelease,Genre")] Movie movie)
    {
      if (id != movie.UID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(movie);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MovieExists(movie.UID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(movie);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var movie = await _context.Movies
          .SingleOrDefaultAsync(m => m.UID == id);
      if (movie == null)
      {
        return NotFound();
      }

      return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var movie = await _context.Movies.SingleOrDefaultAsync(m => m.UID == id);
      _context.Movies.Remove(movie);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int id)
    {
      return _context.Movies.Any(e => e.UID == id);
    }
  }
}
