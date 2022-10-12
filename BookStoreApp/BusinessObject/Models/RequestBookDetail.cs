using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class RequestBookDetail
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? RealQuantity { get; set; }
        public int? RequestBookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual RequestBook RequestBook { get; set; }
    }
}
