using Microsoft.Extensions.DependencyInjection;
using System;
using Task_Manager_Application;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IBuilder, Builder>()
    .AddSingleton<ITaskService, TaskService>()
    .AddSingleton<ITaskList, TaskList>()
    .AddSingleton<ITaskTemplate, TaskTemplate>()
    .AddTransient<Func<TaskTemplate>>(sp => () => new TaskTemplate())
    .AddTransient<TaskTemplate>();

var serviceBuilder = serviceCollection.BuildServiceProvider();
var taskService = serviceBuilder.GetService<ITaskService>();


while (true)
{
    Console.WriteLine("\nMenu:" +
        "\n1. Add task" +
        "\n2. View tasks" +
        "\n3. Remove task" +
        "\n4. End & Save tasks");
    Console.Write("\nPlease choose your action: ");
    int userMenuActionInput = Convert.ToInt32(Console.ReadLine());

    switch (userMenuActionInput)
    {
        case 1:
            Case1AddTask(taskService!);
            break;

        case 2:
            Case2ViewAllTasks(taskService!);
            break;

        case 3:
            Case3RemoveTask(taskService!);
            break;

        case 4:
            return;

        default:
            Console.Write("\nPlease enter nummber from 1 to 4" +
                "\nPress enter to continue ");
            Console.ReadLine();
            break;
    }


    static void Case1AddTask(ITaskService taskService)
    {
        while (true)
        {
            Console.Write("Please enter task name: ");
            string userTaskNameInout = GetValidTaskNameInput();

            Console.Write("Please enter task description: ");
            string userTaskDescriptionInput = Console.ReadLine()!;

            Console.Write("Enter due date (dd-mm-yyyy or similar): ");
            DateTime userTaskDueDateInput = GetValidDueDateInput();



            taskService.CreateTask(builder =>
            {
                builder.SetName(userTaskNameInout!);
                builder.SetDescription(userTaskDescriptionInput);
                builder.SetDueDate(userTaskDueDateInput);
            }
            );
            return;
        }
    }

    static string GetValidTaskNameInput()
    {
        while (true)
        {
            string userTaskNameInput = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(userTaskNameInput))
            {
                return userTaskNameInput;
            }
            Console.Write("Please enter valid task name: ");
        }
    }

    static DateTime GetValidDueDateInput()
    {
        while (true)
        {
            try
            {
                DateTime userTaskDueDateInput = DateTime.Parse(Console.ReadLine()!);
                return userTaskDueDateInput;
            }
            catch
            {
                Console.Write("Please enter valid date: ");
            }
        }
    }


    static void Case2ViewAllTasks(ITaskService taskService)
    {
        List<TaskTemplate> tasks = taskService.ViewTasks();

        if (taskService.GetNumberOfTasks() == 0)
        {
            Console.WriteLine("There are no tasks to show" +
                "\nPress enter to continue ");
            Console.ReadLine();
            return;
        }

        foreach (TaskTemplate task in tasks)
        {
            Console.WriteLine($"Index: {task.Id}" +
                $"\nName: {task.Name}" +
                $"\nDescription: {task.Description}" +
                $"\nDue Date: {task.DueDate}" +
                $"---------------------");
        }
    }


    static void Case3RemoveTask(ITaskService taskService)
    {
        if (taskService.GetNumberOfTasks() == 0)
        {
            Console.WriteLine("There are no tasks to remove" +
                "\nPress enter to continue ");
            Console.ReadLine();
            return;
        }

        Console.Write("Please enter task id: ");
        int id = GetValidTaskIdInput(taskService);
        taskService.DeleteTask(id);
    }

    static int GetValidTaskIdInput(ITaskService taskService)
    {
        int numberOfTasks = taskService.GetNumberOfTasks();
        while (true)
        {
            int id = Convert.ToInt32(Console.ReadLine());
            if (id > 0 || id < numberOfTasks)
            {
                return id;
            }
            Console.WriteLine($"Please enter number from one to {numberOfTasks}");
        }
    }
}