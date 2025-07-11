namespace GuestManagement.Data.Entities
{
    public class Guest : Entity
    {
        public long GenderId { get; set; }

        public long CheckInId { get; set; }

        public required virtual Gender Gender { get; set; }

        public required virtual CheckIn CheckIn { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}