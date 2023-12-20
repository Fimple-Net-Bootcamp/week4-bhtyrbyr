using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Domain.Entities
{
    public class ActivityPermision
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public UInt16 Id { get; set; }
        public UInt16 PetId { get; set; }

        [ForeignKey("PetId")]
        public Pet Pet { get; set; }

        public UInt16 ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
    }
}
