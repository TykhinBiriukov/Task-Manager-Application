namespace Task_Manager_Application
{
    public interface ITaskList
    {
        void AddTask(TaskTemplate task);
        List<TaskTemplate> ViewAllTasks();
        void RemoveTask(int id);
        void SaveTasks();
        List<TaskTemplate> LoadTasks();
    }
}