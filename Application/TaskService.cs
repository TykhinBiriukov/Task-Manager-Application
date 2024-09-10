namespace Task_Manager_Application
{
    public class TaskService : ITaskService
    {
        private readonly ITaskList _taskList;
        private readonly IBuilder _builder;

        public TaskService(ITaskList taskList, IBuilder builder)
        {
            _taskList = taskList;
            _builder = builder;
        }

        public void CreateTask(Action<IBuilder> build)
        {
            build(_builder);
            var task = _builder.BuildTask();
            _taskList.AddTask(task);
        }

        public List<TaskTemplate> ViewTasks()
        {
            return _taskList.ViewAllTasks();
        }

        public void DeleteTask(int id)
        {
            _taskList.RemoveTask(id);
        }

        public int GetNumberOfTasks()
        {
            var tasks = _taskList.ViewAllTasks();
            int numberOfTasks = tasks.Count;
            return numberOfTasks;
        }

        public void TaskSaver()
        {
            _taskList.SaveTasks();
        }

        public List<TaskTemplate> TaskLoader()
        {
            return _taskList.LoadTasks();
        }
    }
}