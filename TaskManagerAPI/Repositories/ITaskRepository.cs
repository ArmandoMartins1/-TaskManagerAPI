public interface ITaskRepository
{
    Task<IEnumerable<Task>> GetAll();
    Task<Task> GetById(int id);
    Task Create(Task task);
    Task Update(Task task);
    Task Delete(int id);
}
