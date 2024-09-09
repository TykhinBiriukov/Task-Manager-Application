namespace Task_Manager_Application
{
    public interface ITaskService
    {
        void CreateTask(Action<IBuilder> build);
        List<TaskTemplate> ViewTasks();
        void DeleteTask(int id);
        int GetNumberOfTasks();
    }
}