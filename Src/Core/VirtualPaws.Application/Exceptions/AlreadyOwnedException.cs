using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Application.Exceptions
{
    public class AlreadyOwnedException : Exception
    {
        public AlreadyOwnedException(string Message) : base(Message)
        { }

        public AlreadyOwnedException() : this("This pet is already owned!")
        { }
    }
}
