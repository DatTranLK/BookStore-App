using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class BookInStore
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? StoreId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Store Store { get; set; }
    }
}
