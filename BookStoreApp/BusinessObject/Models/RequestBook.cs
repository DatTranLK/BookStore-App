using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class RequestBook
    {
        public RequestBook()
        {
            RequestBookDetails = new HashSet<RequestBookDetail>();
        }

        public int Id { get; set; }
        public string AddBookState { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Quantity { get; set; }
        public bool? AcceptedImport { get; set; }
        public int? StaffId { get; set; }

        public virtual Account Staff { get; set; }
        public virtual ICollection<RequestBookDetail> RequestBookDetails { get; set; }
    }
}
