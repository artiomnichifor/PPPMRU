using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_v1.Validations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public sealed class PositiveNumberAtribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var mvr = new ModelClientValidationRule
            {
                ErrorMessage = "This field requires a positive number",
                ValidationType = "positivenumber"
            };
            return new[] { mvr };
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null){
                long number;
                if (long.TryParse(value.ToString(), out number))
                {
                    if (number > 0) return ValidationResult.Success;
                    else return new ValidationResult("This field require positive number");
                }
            }
            return new ValidationResult("value is null");
        }
    }
}