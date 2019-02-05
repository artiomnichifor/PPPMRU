using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_v1.Validations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class PastDateAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var mvr = new ModelClientValidationRule
            {
                ErrorMessage = "This is not a data from past",
                ValidationType = "pastdata"
            };
            return new[] { mvr };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || (DateTime)value > DateTime.Now)
                return new ValidationResult("this data is from the future or is null");

            return ValidationResult.Success;
        }


        //public override bool IsValid(object value)
        //{
        //    if (value == null || (DateTime)value < DateTime.Now)
        //        return false;

        //    return true;
        //}

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    yield return new ModelClientValidationRule
        //    {
        //        ErrorMessage = this.ErrorMessage,
        //        ValidationType = "futuredate"
        //    };
        //}
    }
}