namespace Application.Profiles;

public interface IConvertibleFromEntity<TEntity, TResponse>
{
    static abstract TResponse FromEntity(TEntity entity);
}