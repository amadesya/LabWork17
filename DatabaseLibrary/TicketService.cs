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
    public class TicketService
    {
        public async Task<List<Ticket>> GetTicketsAsync()
        {
            using var context = new CinemaContext();
            return await context.Tickets.ToListAsync();
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            using var context = new CinemaContext();
            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            using var context = new CinemaContext();
            var currentTicket = await context.Tickets.FindAsync(ticket.IdTicket);
            if (currentTicket != null)
            {
                currentTicket.Row = ticket.Row;
                currentTicket.Place = ticket.Place;
                currentTicket.IdVisitor = ticket.IdVisitor;
                currentTicket.IdSession = ticket.IdSession;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTicketAsync(int id)
        {
            using var context = new CinemaContext();
            var ticket = await context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                context.Tickets.Remove(ticket);
                await context.SaveChangesAsync();
            }
        }
    }
}
