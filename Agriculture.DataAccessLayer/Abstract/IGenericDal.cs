namespace Agriculture.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class, new()
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetList();
    }
}
