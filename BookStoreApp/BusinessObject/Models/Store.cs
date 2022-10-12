using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class Store
    {
        public Store()
        {
            Accounts = new HashSet<Account>();
            BookInStores = new HashSet<BookInStore>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<BookInStore> BookInStores { get; set; }
    }
}
