using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
    }
}
