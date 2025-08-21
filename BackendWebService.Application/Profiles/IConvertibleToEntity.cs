namespace Application.Profiles;

public interface IConvertibleToEntity<TEntity>
{
    TEntity ToEntity();
}