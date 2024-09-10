namespace Task_Manager_Application
{
    public class TaskTemplate : ITaskTemplate
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}