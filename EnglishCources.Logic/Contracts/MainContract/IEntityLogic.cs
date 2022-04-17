namespace EnglishCources.Logic.Contracts
{
    public interface IEntityLogic<T>
    {
        int Add(T entity);
        int Update(int entityId, T newEntity);
        int Delete(int entityId);
        T GetById(int entityId);
        IEnumerable<T> GetAll();
    }
}
