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


try
{
    taskService!.TaskLoader();
}
catch { }


while (true)
{
    Console.WriteLine("\nMenu:" +
        "\n1. Add task" +
        "\n2. View tasks" +
        "\n3. Remove task" +
        "\n4. End & Save tasks");
    Console.Write("\nPlease choose your action: ");
    int userMenuActionInput;
    try
    {
        userMenuActionInput = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        userMenuActionInput = 5;
    }
    
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
            taskService!.TaskSaver();
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

        if (CheckIfTaskNuymberIs0(taskService))
        {
            return;
        }

        int id = 1;
        foreach (TaskTemplate task in tasks)
        {
            Console.WriteLine($"Task id: {id++}" +
                $"\nName: {task.Name}" +
                $"\nDescription: {task.Description}" +
                $"\nDue Date: {task.DueDate}" +
                $"\n---------------------");
        }
    }


    static void Case3RemoveTask(ITaskService taskService)
    {
        if (CheckIfTaskNuymberIs0(taskService))
        {
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
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                if (id > 0 && id < numberOfTasks)
                {
                    return id;
                }
                Console.Write($"Please enter number from 1 to {numberOfTasks}: ");
            }
            catch
            {
                Console.Write($"Please enter number from 1 to {numberOfTasks}: ");
            }
        }
    }


    static bool CheckIfTaskNuymberIs0(ITaskService taskService)
    {
        if (taskService.GetNumberOfTasks() == 0)
        {
            Console.Write("There are no tasks in the list" +
                "\nPress enter to continue ");
            Console.ReadLine();
            return true;
        }
        return false;
    }
}