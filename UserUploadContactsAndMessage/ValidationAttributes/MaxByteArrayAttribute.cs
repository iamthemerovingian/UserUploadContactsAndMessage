using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserUploadContactsAndMessage.ValidationAttributes
{
    public class MaxByteArrayAttribute : ValidationAttribute
    {
        private readonly int _maximumSize;
        private readonly int _minimumSize;
        public MaxByteArrayAttribute(int maximumSize =1024, int minimumSize = 20) : base($"File must be between {minimumSize} and {maximumSize} bytes.")
        {
            _maximumSize = maximumSize;
            _minimumSize = minimumSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = (byte[])value;
                int valueAsInt = valueAsString.Length;
                if (_maximumSize < valueAsInt ||   _minimumSize > valueAsInt)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}