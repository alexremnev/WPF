using System.Collections.ObjectModel;
using System.IO;
using Task_Scheduler.Models;

namespace Task_Scheduler.Service
{
   public static class TaskService
    {
        public static ObservableCollection<Task> List()
        {
            return TaskRepository.List();
        }

        public static void Add(Task task)
        {
            TaskRepository.Add(task);
        }

        public static void Delete(Task task)
        {
            TaskRepository.Delete(task);
        }

        public static void Update(ObservableCollection<Task> list)
        {
            TaskRepository.Update(list, FileMode.Truncate);
        }
    }
}
