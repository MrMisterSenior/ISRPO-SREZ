using System;
using System.Collections.Generic;

namespace Srez.Models
{
    public class Sale
    {
        public DateTime DateSale { get; set; }
        public Client Client { get; set; }
        public List<Telephone> Telephones { get; set; }

    }
}