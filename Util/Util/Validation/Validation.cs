using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;

namespace Util.Validation
{
    public class Validation : IValidation
    {
        private object _target;
        private readonly ValidationResultCollection _results;

        public Validation()
        {
            _results = new ValidationResultCollection();
        }

        public ValidationResultCollection Validate(object target)
        {
            _target = target;

            return _results;
        }

        private void ValidateProperty(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof (ValidationAttribute), true);
            foreach (var attribute in attributes)
            {
                var validationAttribute = attribute as ValidationAttribute;
                if (validationAttribute == null)
                    continue;
                ValidateAttribute(property, validationAttribute);
            }
        }

        private void ValidateAttribute(PropertyInfo property, ValidationAttribute attribute)
        {
            var isValid = attribute.IsValid(property.GetValue(_target));
            if (isValid)
                return;
            _results.Add(new ValidationResult(GetErrorMessage(attribute))); 
        }

        private string GetErrorMessage(ValidationAttribute attribute)
        {
            if (!string.IsNullOrEmpty(attribute.ErrorMessage))
                return attribute.ErrorMessage;
            return GetString(attribute.ErrorMessageResourceType.FullName, attribute.ErrorMessageResourceName, attribute.ErrorMessageResourceType.Assembly);
        }
    }
}
