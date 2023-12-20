using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Application.DTOs.PetFoodDTOs
{
    public class PetFoodUpdateDTO
    {
        public string NewName { get; set; }
        public byte NewNutritionalValue { get; set; }
    }
}
