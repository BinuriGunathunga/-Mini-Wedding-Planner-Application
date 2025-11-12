using TaskService.Models;

namespace TaskService.Data
{
    public class TaskDbContext0021
    {
        private readonly List<Task0021> _tasks = new();
        private int _nextId = 1;

        public List<Task0021> GetAllTasks0021()
        {
            return _tasks;
        }

        public List<Task0021> GetTasksByEventId0021(int eventId)
        {
            return _tasks.Where(t => t.EventId == eventId).ToList();
        }

        public Task0021? GetTaskById0021(int id)
        {
            return _tasks.FirstOrDefault(t => t.TaskId == id);
        }

        public Task0021 AddTask0021(Task0021 task)
        {
            task.TaskId = _nextId++;
            _tasks.Add(task);
            return task;
        }

        public bool UpdateTask0021(int id, Task0021 updatedTask)
        {
            var task = GetTaskById0021(id);
            if (task == null) return false;

            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;
            return true;
        }

        public bool DeleteTask0021(int id)
        {
            var task = GetTaskById0021(id);
            if (task == null) return false;
            _tasks.Remove(task);
            return true;
        }
    }
}