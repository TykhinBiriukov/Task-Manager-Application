

namespace Task_Manager_Application
{
    public class Builder : IBuilder
    {
        private readonly TaskTemplate _task;

        public Builder(TaskTemplate task) 
        {
            _task = task;
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

        public TaskTemplate BuildTask()
        {
            return _task;
        }
    }
}
