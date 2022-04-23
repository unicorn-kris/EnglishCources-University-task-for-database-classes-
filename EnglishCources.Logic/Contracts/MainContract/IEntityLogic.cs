namespace EnglishCources.Logic.Contracts
{
    public interface IEntityLogic<T>
    {
        int Add(T entity);
        void Update(int entityId, T newEntity);
        void Delete(int entityId);
        T GetById(int entityId);
        IEnumerable<T> GetAll();
    }
}
