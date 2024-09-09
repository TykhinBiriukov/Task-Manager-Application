namespace Task_Manager_Application
{
    public interface ITaskTemplate
    {
        string? Name { get; set; }
        string? Description { get; set; }
        DateTime DueDate { get; set; }
    }
}
