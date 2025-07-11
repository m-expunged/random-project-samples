namespace GuestManagement.Data.Entities
{
    public class CheckIn : Entity
    {
        public long CheckInTypeId { get; set; }

        public required virtual CheckInType CheckInType { get; set; }

        public required DateTimeOffset Time { get; set; }
    }
}