using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.Data;
using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary
{
    public class GenreService
    {
        public async Task<List<Genre>> GetCategoriesAsync()
        {
            using var context = new CinemaContext();
            return await context.Genres.ToListAsync();
        }

        public async Task AddCategoryAsync(Genre genre)
        {
            using var context = new CinemaContext();
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            using var context = new CinemaContext();
            var genre = await context.Genres.FindAsync(id);
            if (genre != null)
            {
                context.Genres.Remove(genre);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategoryAsync(Genre genre, int id)
        {
            using var context = new CinemaContext();
            var currentGenre = await context.Genres.FindAsync(id);
            if (currentGenre != null)
            {
                currentGenre.GenreName = genre.GenreName;
                await context.SaveChangesAsync();
            }
        }
    }
}
