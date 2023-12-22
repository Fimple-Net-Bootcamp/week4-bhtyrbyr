using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Application.DTOs.RecordDTOs
{
    public class FeedRecordViewDTO
    {
        public UInt16 Id { get; set; }
        public string UserName { get; set; }
        public string PetName { get; set; }
        public string FoodName { get; set; }
        public string Comtroller { get; set; }
        public DateTime Date { get; set; }
    }
}
