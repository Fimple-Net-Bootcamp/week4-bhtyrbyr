using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Application.DTOs.RecordDTOs
{
    public class ActivityRecordViewDTO
    {
        public UInt16 Id { get; set; }
        public string UserName { get; set; }
        public string PetName { get; set; }
        public string ActivityName { get; set; }
        public string Comtroller { get; set; }
        public DateTime Date { get; set; }
    }
}
