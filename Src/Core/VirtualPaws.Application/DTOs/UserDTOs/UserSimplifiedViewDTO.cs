﻿namespace VirtualPaws.Application.DTOs.UserDTOs
{
    public class UserSimplifiedViewDTO
    {
        public UInt16 Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PetCount { get; set; }
        public bool IsActive { get; set; }
    }
}
