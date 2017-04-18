using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserUploadContactsAndMessage.Models
{
    public class UserDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public byte[] Contacts { get; set; }

        public DateTime SendDateTime { get; set; }

    }
}