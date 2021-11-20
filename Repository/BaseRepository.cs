namespace MvcGuestBook.Repository;

public abstract class BaseRepository<T> where T : class
{
    public abstract void Insert(T item);

    public abstract T Get(Guid id);

    public abstract List<T> GetAll();
}