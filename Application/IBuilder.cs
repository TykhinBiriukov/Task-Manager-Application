namespace Task_Manager_Application
{
    public interface IBuilder
    {
        void SetName(string name);
        void SetDescription(string description);
        void SetDueDate(DateTime dueDate);
        TaskTemplate BuildTask();
        void Reset();
    }
}