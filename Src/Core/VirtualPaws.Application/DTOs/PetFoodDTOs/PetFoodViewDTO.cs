﻿namespace VirtualPaws.Application.DTOs.PetFoodDTOs
{
    public class PetFoodViewDTO
    {
        public UInt16 Id { get; set; }
        public string Name { get; set; }
        public byte NutritionalValue { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
