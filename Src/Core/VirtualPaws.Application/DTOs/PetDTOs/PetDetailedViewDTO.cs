namespace VirtualPaws.Application.DTOs.PetDTOs
{
    public class PetDetailedViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public byte Level { get; set; }
        public byte XP { get; set; }
        public byte HungerScore { get; set; }
        public List<string> Activities { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
