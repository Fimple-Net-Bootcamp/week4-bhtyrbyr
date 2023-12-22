using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Application.Exceptions
{
    public class NoCapabilityForActivityException : Exception
    {
        public NoCapabilityForActivityException(string Message) : base(Message) { }

        public NoCapabilityForActivityException(string PetName, string ActivityName) : this($"This pet {PetName} is not capable of doing activity {ActivityName}!")
        { }
    }
}
