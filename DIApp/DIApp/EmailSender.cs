using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIApp
{
    public class EmailSender
    {
        private AddressService addressService;

        public EmailSender(AddressService addressService)
        {
            this.addressService = addressService;
        }
    }
}
