namespace VirtualPaws.Application.DTOs.PetDTOs
{
    public class PetCreateDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Activities { get; set; }
    }
}
