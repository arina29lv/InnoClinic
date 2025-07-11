using Microsoft.EntityFrameworkCore;
using StaffControl.Domain.Entities;
using StaffControl.Domain.Interfaces;
using StaffControl.Infrastructure.Persistence;

namespace StaffControl.Infrastructure.Repositories
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly StaffDbContext _context;

        public ReceptionistRepository(StaffDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _context.Receptionists.ToListAsync();
        }

        public async Task<Receptionist?> GetByIdAsync(Guid id)
        {
            return await _context.Receptionists.FindAsync(id);
        }

        public async Task AddAsync(Receptionist receptionist)
        {
            _context.Receptionists.Add(receptionist);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var receprionist = await _context.Receptionists.FindAsync(id);

            if (receprionist != null)
            {
                _context.Receptionists.Remove(receprionist);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Receptionist receptionist)
        {
            _context.Receptionists.Update(receptionist);
            await _context.SaveChangesAsync();
        }
    }
}
