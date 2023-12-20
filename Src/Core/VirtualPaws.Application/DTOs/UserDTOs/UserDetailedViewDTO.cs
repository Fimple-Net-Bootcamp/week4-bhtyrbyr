using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Application.DTOs.UserDTOs
{
    public class UserDetailedViewDTO
    {
        public UInt16 Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> PetsName { get; set; } = new List<string>();
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
