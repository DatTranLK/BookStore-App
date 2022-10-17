﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject.Models
{
    public partial class Account
    {
        public Account(string username,string password)
        {
            Username = username;
            Password = password;
        }
        public Account()
        {
            OrderCustomers = new HashSet<Order>();
            OrderStaffs = new HashSet<Order>();
            RequestBooks = new HashSet<RequestBook>();
        }

        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
        public int? StoreId { get; set; }
        public string Address { get; set; }

        public virtual Role Role { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<Order> OrderCustomers { get; set; }
        public virtual ICollection<Order> OrderStaffs { get; set; }
        public virtual ICollection<RequestBook> RequestBooks { get; set; }
    }
}
