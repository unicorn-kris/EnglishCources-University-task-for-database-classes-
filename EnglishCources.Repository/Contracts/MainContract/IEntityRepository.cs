namespace EnglishCources.Repository.Contracts
{
    public interface IEntityRepository<T>
    {
        int Add(T entity);
        int Update(int entityId, T newEntity);
        int Delete(int entityId);
        T GetById(int entityId);
        IEnumerable<T> GetAll();
    }
}
