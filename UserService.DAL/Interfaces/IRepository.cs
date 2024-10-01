namespace UserService.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> getItems(string name);
    }
}
