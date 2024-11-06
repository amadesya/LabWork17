using DatabaseLibrary.Data;
using DatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary
{
    public class FilmService
    {
        public async Task<List<Film>> GetCategoriesAsync()
        {
            using var context = new CinemaContext();
            return await context.Films.ToListAsync();
        }

        public async Task AddCategoryAsync(Film film)
        {
            using var context = new CinemaContext();
            context.Films.Add(film);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            using var context = new CinemaContext();
            var category = await context.Films.FindAsync(id);
            if (category != null)
            {
                context.Films.Remove(category);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategoryAsync(Film film, int id)
        {
            using var context = new CinemaContext();
            var currentFilm = await context.Films.FindAsync(id);
            if (currentFilm != null)
            {
                currentFilm.FilmName = film.FilmName;
                await context.SaveChangesAsync();
            }
        }
    }
}
