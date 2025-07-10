using System.ComponentModel.DataAnnotations;

namespace StaffControl.Domain.Entities
{
    public class Receptionist
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Guid AccountId { get; set; }
        public Guid OfficeId { get; set; }
        
    }
}
