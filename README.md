# Task Management Application

Task Management Application is a console-based pet-project for managing tasks, allowing users to create, view, save/load and delete tasks. It shows the use of the **Builder Pattern** for constructing task objects,**Dependency Injection** for managing dependencies and **System.Text.Json** for saving and loading tasks in Json format.

---

## 📦 Tech Stack

### Languages
- C#

### Frameworks / Libraries
- .NET Core
- Dependency Injection via `Microsoft.Extensions.DependencyInjection`
- Saving/Loading tasks from/to Json via `System.Text.Json`


### Backend

- **Dependency Injection (DI):** Used to inject the task builder, task service, task template and task list dependencies.
- **Builder Pattern:** Used to construct `TaskTemplate` objects.
- **Console Application:** User interacts with the system through a simple console interface.

---

## 🛠 Features

### 1. Create Tasks
- Users can create a task by specifying the task title, description, due date, and initial status.
- User input is validated to ensure that it is not null and the date format is correct.

### 2. View Tasks
- List all tasks, showing the task ID, title, and current status.

### 3. Delete Tasks
- Remove a task from the list by selecting its task ID.

### 4. Save and Load Tasks
- Application automatically save and load tasks provided by user.


