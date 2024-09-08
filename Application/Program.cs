using Microsoft.Extensions.DependencyInjection;
using System;
using Task_Manager_Application;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IBuilder, Builder>()
    .AddSingleton<ITaskService, TaskService>()
    .AddSingleton<ITaskList, TaskList>()
    .AddSingleton<ITaskTemplate, TaskTemplate>()
    .AddTransient<TaskTemplate>();

var serviceBuilder = serviceCollection.BuildServiceProvider ();
var taskService = serviceBuilder.GetService<ITaskService>();


while (true)
{
    Console.WriteLine("Menu:" +
        "\n1. Add task" +
        "\n2. View tasks" +
        "\n3. Remove task" +
        "\n4. End & Save tasks" +
        "\n\nPlease choose your action: ");
    int userMenuActionInput = Convert.ToInt32(Console.ReadLine());

    switch (userMenuActionInput)
    {
        case 1:
            Case1AddTask(taskService!);
            break;

        case 2:
            Case2ViewAllTasks();
            break;

        case 3:
            Case3RemoveTask();
            break;

        case 4:
            return;

        default:
            Console.WriteLine("Please enter nummber from 1 to 4" +
                "\nPress enter to continue");
            Console.ReadLine();
            break;
    }


    static void Case1AddTask(ITaskService taskService)
    {
        bool breakingFlag = true;
        string userTaskNameInout = null!;

        while (true)
        {
            Console.WriteLine("Please enter task name");
            while (breakingFlag)
            {
                userTaskNameInout = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(userTaskNameInout))
                {
                    breakingFlag = false;
                }
                Console.WriteLine("Please enter valid task name");
            }

            Console.WriteLine("Please enter task description");
            string userTaskDescriptionInput = Console.ReadLine()!;

            Console.Write("Enter due date (yyyy-mm-dd): ");
            DateTime userTaskDueDateInput = DateTime.Parse(Console.ReadLine()!);
            

            taskService.CreateTask(builder => 
                {
                    builder.SetName(userTaskNameInout!);
                    builder.SetDescription(userTaskDescriptionInput);
                    builder.SetDueDate(userTaskDueDateInput);
                }
            );
        }
    }

    static void Case2ViewAllTasks()
    {

    }

    static void Case3RemoveTask()
    {

    }
}