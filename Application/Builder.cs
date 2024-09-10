namespace Task_Manager_Application
{
    public class Builder : IBuilder
    {
        private TaskTemplate _task;
        private readonly Func<TaskTemplate> _taskFactory;

        public Builder(Func<TaskTemplate> taskFactory) 
        {
            _taskFactory = taskFactory;
            Reset();
        }

        public void SetDescription(string description)
        {
            _task.Description = description;
        }   

        public void SetName(string name)
        {
            _task.Name = name;
        }

        public void SetDueDate(DateTime dueDate)
        {
            _task.DueDate = dueDate;
        }

        public void Reset()
        {
            _task = _taskFactory();
        }

        public TaskTemplate BuildTask()
        {
            TaskTemplate resultTask = _task;
            Reset();
            return resultTask;
        }
    }
}