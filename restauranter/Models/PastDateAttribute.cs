using System.ComponentModel.DataAnnotations;


namespace restauranter.Models
{
    public class PastDateAtrribute :ValidationAttribute
    {
        private System.DateTime _targetdate;
        public PastDateAtrribute()
        {
            _targetdate = System.DateTime.Now;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((System.DateTime)value > _targetdate)
            {
                return new ValidationResult("Date time can not be in the future !");
            }
            return ValidationResult.Success;
        }
                   
    }
}