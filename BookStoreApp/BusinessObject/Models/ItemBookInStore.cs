using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class ItemBookInStore
    {
        public BookInStore BookInStore { get; set; }

        public int Quantity { get; set; }
    }
}
