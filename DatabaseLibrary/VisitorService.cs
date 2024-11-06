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
    public class VisitorService
    { 

        public async Task<List<Visitor>> GetVisitorsAsync()
        {
            using var context = new CinemaContext();
            return await context.Visitors.ToListAsync();
        }

        public async Task AddVisitorAsync(Visitor visitor)
        {
            using var context = new CinemaContext();
            context.Visitors.Add(visitor);
            await context.SaveChangesAsync();
        }

        public async Task UpdateVisitorAsync(Visitor visitor)
        {
            using var context = new CinemaContext();
            var currentVisitor = await context.Visitors.FindAsync(visitor.IdVisitor);
            if (currentVisitor != null)
            {
                currentVisitor.Name = visitor.Name;
                currentVisitor.Birthdate = visitor.Birthdate;
                currentVisitor.PhoneNumber = visitor.PhoneNumber;
                currentVisitor.Email = visitor.Email;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteVisitorAsync(int id)
        {
            using var context = new CinemaContext();
            var visitor = await context.Visitors.FindAsync(id);
            if (visitor != null)
            {
                context.Visitors.Remove(visitor);
                await context.SaveChangesAsync();
            }
        }
    }
}
