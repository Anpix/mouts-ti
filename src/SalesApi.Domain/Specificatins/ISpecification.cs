namespace SalesApi.Domain.Specificatins;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
}
