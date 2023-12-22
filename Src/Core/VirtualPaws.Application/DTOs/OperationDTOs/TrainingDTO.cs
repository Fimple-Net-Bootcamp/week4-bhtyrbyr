using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Application.DTOs.OperationDTOs
{
    public class TrainingDTO
    {
        public UInt16 UserId { get; set; }
        public UInt16 PetId { get; set; }
        public UInt16 TrainigId { get; set; }
    }
}
