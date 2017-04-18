using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserUploadContactsAndMessage.ValidationAttributes;

namespace UserUploadContactsAndMessage.Models
{
    public class UserDetail :IValidatableObject
    {
        private UserUploadContactsAndMessageDb _db = new UserUploadContactsAndMessageDb();
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 160, MinimumLength = 2)]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength:160, MinimumLength = 20)]
        [NoIllegalCharacters]
        public string Message { get; set; }

        //Added to prevent Overloadig the database with CSV files.
        [MaxByteArray(maximumSize:100000, minimumSize: 20)]
        public byte[] Contacts { get; set; }

        [Display(Name = "Send Date and Time")]
        public DateTime SendDateTime { get; set; }

        [StringLength(maximumLength: 160, MinimumLength = 5)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        internal HttpPostedFileBase FileDetails { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var lastUserEntry = (from u in _db.UserDetails
                                 orderby u.Id descending
                                 select u).FirstOrDefault();

            if (SendDateTime != DateTime.MinValue && Message != null && lastUserEntry != null)
            {
                if (lastUserEntry.Message.ToLower().Equals(Message.ToLower()))
                {
                    if (lastUserEntry.SendDateTime > SendDateTime.AddHours(-24) && lastUserEntry.SendDateTime <= SendDateTime)
                    {
                        yield return new ValidationResult("Sorry, you can't insert the same message twice in 24h hours!");
                    }
                }
            }
        }
    }
}