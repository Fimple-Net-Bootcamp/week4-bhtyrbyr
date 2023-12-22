namespace VirtualPaws.Domain.Entities
{
    public class ActivityPet
    {
        public UInt16 PetId { get; set; }
        public Pet Pet { get; set; }
        public UInt16 ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
