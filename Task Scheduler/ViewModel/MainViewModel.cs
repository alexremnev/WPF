using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Task_Scheduler.Models;

namespace Task_Scheduler.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Task _selectedTask;
        private string _selectedTaskState;
        private string _selectedTaskPriority;

        public MainViewModel()
        {
            LoadCommand = new RelayCommand(LoadMethod);
            SaveCommand = new RelayCommand(SaveMethod);
            DeleteCommand = new RelayCommand(DeleteMethod);
        }

        public ICommand LoadCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public ObservableCollection<Task> TaskList { get; set; }

        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> TaskState { get; } = new ObservableCollection<string>()
        {
            "Active",
            "In Progress",
            "Done",
            "Suspended"
        };

        public string SelectedTaskState
        {
            get { return _selectedTaskState; }
            set
            {
                _selectedTaskState = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> TaskPriority { get; } = new ObservableCollection<string>()
        {
            "Lowest",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "Highest"
        };

        public string SelectedTaskPriority
        {
            get { return _selectedTaskPriority; }
            set
            {
                _selectedTaskPriority = value;
                RaisePropertyChanged();
            }
        }


        public void SaveMethod()
        {
            Task.Add(_selectedTask);
            LoadMethod();
            //    Messenger.Default.Send(new NotificationMessage("Task Saved."));
        }

        private void LoadMethod()
        {
            TaskList = Task.List();
            RaisePropertyChanged(() => TaskList);
            // Messenger.Default.Send(new NotificationMessage("Tasks Loaded."));
        }

        private void DeleteMethod()
        {
            Task.Delete(_selectedTask);
            LoadMethod();
        }
    }
}