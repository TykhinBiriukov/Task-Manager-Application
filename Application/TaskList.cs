using System.Text.Json;
using System.Threading.Tasks;

namespace Task_Manager_Application
{
    public class TaskList : ITaskList
    {
        private readonly List<TaskTemplate> _tasks = new List<TaskTemplate>();
        private int _taskId = 0;

        public void AddTask(TaskTemplate task)
        {
            task.Id = ++_taskId;
            _tasks.Add(task);
        }

        public List<TaskTemplate> ViewAllTasks()
        {
            return _tasks;
        }

        public void RemoveTask(int id)
        {
            _tasks.RemoveAt(id - 1);
        }
    }
}
