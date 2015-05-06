namespace Util.Validations
{
    public interface IValidation
    {
        ValidationResultCollection Validate(object target);
    }
}
