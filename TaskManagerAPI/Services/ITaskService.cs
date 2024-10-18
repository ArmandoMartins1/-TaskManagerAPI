public interface ITaskService
{
    Task<IEnumerable<TaskDTO>> GetTasks(TaskFilterDTO filter);
    Task<TaskDTO> CreateTask(TaskDTO taskDTO);
}
