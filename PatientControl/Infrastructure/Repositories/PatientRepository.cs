using Microsoft.EntityFrameworkCore;
using PatientControl.Domain.Entities;
using PatientControl.Domain.Interfaces;
using PatientControl.Infrastructure.Persistence;

namespace PatientControl.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _context;

        public PatientRepository(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Patient> GetByAccountIdAsync(Guid accountId)
        {
            return await _context.Patients
                .Where(p => p.AccountId == accountId)
                .SingleOrDefaultAsync();
        }
    }
}
