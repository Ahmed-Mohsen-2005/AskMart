namespace Domain.Interfaces.ModelValidationInterfaces
{
    public interface IModelValidation<T>
    {
        void Validate(T entity);
    }
}
