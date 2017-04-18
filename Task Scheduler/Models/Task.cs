using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;

namespace Task_Scheduler.Models
{
    [Serializable]
    public class Task : ObservableObject
    {
        private string title;
        private string description;
        private string state;
        private DateTime startDate;
        private DateTime endDate;
        private string priority;

        public string Title
        {
            get { return title; }
            set { Set(() => Title, ref title, value); }
        }

        public string Description
        {
            get { return description; }
            set { Set(() => Description, ref description, value); }
        }

        public string State
        {
            get { return state; }
            set { Set(() => State, ref state, value); }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { Set(() => StartDate, ref startDate, value); }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { Set(() => EndDate, ref endDate, value); }
        }

        public string Priority
        {
            get { return priority; }
            set { Set(() => Priority, ref priority, value); }
        }

        public static ObservableCollection<Task> List()
        {
            ObservableCollection<Task> tasks;
            var formatter = new XmlSerializer(typeof(ObservableCollection<Task>));

            using (var fs = new FileStream("Data.xml", FileMode.OpenOrCreate))
            {
                tasks = (ObservableCollection<Task>) formatter.Deserialize(fs);
            }
            return tasks;
        }

        public static void Add(Task task)
        {
            var list = List();
            list.Add(task);
            var formatter = new XmlSerializer(typeof(ObservableCollection<Task>));

            using (var fs = new FileStream("Data.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }
        }

        public static void Delete(Task task)
        {
            var list = List();
            var selectedtask = list.First(x => x.Title == task.Title);
            list.Remove(selectedtask);

            var formatter = new XmlSerializer(typeof(ObservableCollection<Task>));

            using (var fs = new FileStream("Data.xml", FileMode.Truncate))
            {
                formatter.Serialize(fs, list);
            }
        }
    }
}