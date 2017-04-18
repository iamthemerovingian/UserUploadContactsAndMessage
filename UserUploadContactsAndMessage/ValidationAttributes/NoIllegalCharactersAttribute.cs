using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserUploadContactsAndMessage.ValidationAttributes
{
    public class NoIllegalCharactersAttribute : ValidationAttribute
    {
        private char[] _illegatChars = new char[6] { '$', '#', '@', '&', '%', '€' };

        public NoIllegalCharactersAttribute(int maximumSize = 1024, int minimumSize = 20) : base("You cannot have the following characters in your message text: '$', '#', '@', '&', '%', '€' ")
        {
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var Message = value.ToString();

                if (!string.IsNullOrWhiteSpace(Message))
                {
                    foreach (var item in _illegatChars)
                    {
                        if (Message.Contains(item))
                        {
                            return new ValidationResult("You cannot have the following characters in your message text: '$', '#', '@', '&', '%', '€' ");
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}