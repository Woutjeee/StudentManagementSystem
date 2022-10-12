namespace API.Interfaces
{
    public interface IGeneric<T>
    {
        public T GetById(Guid id);

        public List<T> GetAll();

        public void Create(T type);

        public void Update(T type);

        public T Delete(Guid id);

        public bool Exisits(Guid id);
    }
}
