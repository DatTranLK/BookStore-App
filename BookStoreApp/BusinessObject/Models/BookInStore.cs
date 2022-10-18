using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class BookInStore
    {
        public BookInStore()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? StoreId { get; set; }
        public int? Amount { get; set; }

        public virtual Book Book { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
