namespace Util.Validation
{
    public interface IValidation
    {
        ValidationResultCollection Validate(object target);
    }
}
