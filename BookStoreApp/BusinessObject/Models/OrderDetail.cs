using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? BookInStoreId { get; set; }
        public int? Quantity { get; set; }

        public virtual BookInStore BookInStore { get; set; }
        public virtual Order Order { get; set; }
    }
}
