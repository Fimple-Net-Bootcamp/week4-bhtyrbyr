using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.DTOs.ActivityDTOs
{
    public class ActivityViewDTO
    {
        public UInt16 Id { get; set; }
        public string Name { get; set; }
        public byte NutritionalValue { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
