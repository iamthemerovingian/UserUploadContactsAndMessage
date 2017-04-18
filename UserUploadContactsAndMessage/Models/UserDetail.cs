using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserUploadContactsAndMessage.ValidationAttributes;

namespace UserUploadContactsAndMessage.Models
{
    public class UserDetail 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(maximumLength:160, MinimumLength = 20)]
        public string Message { get; set; }
        //Added to prevent Overloadig the database with CSV files.
        //[Required]
        //[MaxByteArray(maximumSize:1024, minimumSize: 20)]
        public byte[] Contacts { get; set; }
        public DateTime SendDateTime { get; set; }
    }
}