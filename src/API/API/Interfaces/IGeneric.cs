namespace API.Interfaces
{
    public interface IGeneric<T>
    {
        public List<T> GetAll();

        public T GetById(Guid id);

        public T Create(T type);

        public T Update(T type);

        public T Delete(T type);

        public bool Exisits(Guid id);
    }
}
