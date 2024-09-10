using System.Text.Json;
using System.Threading.Tasks;

namespace Task_Manager_Application
{
    public class TaskList : ITaskList
    {
        private List<TaskTemplate> _tasks = new List<TaskTemplate>();

        public void AddTask(TaskTemplate task)
        {
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

        public void SaveTasks()
        {
            string fileName = "TaskList.json";
            string result = JsonSerializer.Serialize(_tasks);
            File.WriteAllText(fileName, result);
        }

        public List<TaskTemplate> LoadTasks()
        {
            string fileName = "TaskList.json";
            string jsonString = File.ReadAllText(fileName);
            _tasks = JsonSerializer.Deserialize<List<TaskTemplate>>(jsonString)!;
            return _tasks;
        }
    }
}