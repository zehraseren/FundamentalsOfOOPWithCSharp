namespace Agriculture.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class, new()
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetList();
    }
}
