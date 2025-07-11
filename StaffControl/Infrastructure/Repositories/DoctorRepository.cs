using Microsoft.EntityFrameworkCore;
using StaffControl.Domain.Entities;
using StaffControl.Domain.Interfaces;
using StaffControl.Infrastructure.Persistence;

namespace StaffControl.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly StaffDbContext _context;

        public DoctorRepository(StaffDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(Guid id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task AddAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();

        }
    }
}
