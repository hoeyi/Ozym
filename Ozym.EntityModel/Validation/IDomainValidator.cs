namespace Ozym.EntityModel.Validation
{
    public interface IDomainValidator
    {
        bool ModelIsValid(object model, out IList<string> validationErrors);
    }
}
