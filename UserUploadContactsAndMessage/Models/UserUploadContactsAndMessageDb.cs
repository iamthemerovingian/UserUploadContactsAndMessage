using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserUploadContactsAndMessage.Models
{
    public class UserUploadContactsAndMessageDb :DbContext
    {
        public UserUploadContactsAndMessageDb() :base("name = DefaultConnection")
        {

        }

        public DbSet<UserDetail> UserDetails { get; set; }

    }
}