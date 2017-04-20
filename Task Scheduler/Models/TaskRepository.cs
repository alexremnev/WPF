using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Task_Scheduler.Models
{
    public static class TaskRepository
    {
        private const string Path = "Data.xml";
        private static XmlSerializer formatter { get; } = new XmlSerializer(typeof(ObservableCollection<Task>));

        static TaskRepository()
        {
            if (!File.Exists(Path)) InitFile();
        }

        public static void Update(ObservableCollection<Task> list, FileMode mode)
        {
            using (var fs = new FileStream(Path, mode))
            {
                formatter.Serialize(fs, list);
            }
        }

        public static ObservableCollection<Task> List()
        {
            ObservableCollection<Task> tasks;
            using (var fs = new FileStream(Path, FileMode.Open))
            {
                tasks = (ObservableCollection<Task>) formatter.Deserialize(fs);
            }
            return tasks;
        }

        public static void Delete(Task task)
        {
            var list = List();
            var selectedtask = list.First(x => x.Title == task.Title);
            list.Remove(selectedtask);
            Update(list, FileMode.Truncate);
        }

        public static void Add(Task task)
        {
            var list = List();
            list.Add(task);
            Update(list, FileMode.OpenOrCreate);
        }

        private static void InitFile()
        {
            using (var fs = new FileStream(Path, FileMode.Create))
            {
                formatter.Serialize(fs, new ObservableCollection<Task>());
            }
        }
    }
}