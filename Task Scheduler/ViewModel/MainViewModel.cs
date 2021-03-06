﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Task_Scheduler.Models;
using Task_Scheduler.Service;

namespace Task_Scheduler.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Task _selectedTask;
        private StateMode _selectedTaskState;
        private PriorityMode _selectedTaskPriority;

        public static ObservableCollection<StateMode> TaskState { get; } = new ObservableCollection<StateMode>()
        {
            StateMode.Done,
            StateMode.Active,
            StateMode.InProgress,
            StateMode.Suspended
        };

        public static ObservableCollection<PriorityMode> TaskPriority { get; } = new ObservableCollection<PriorityMode>()
        {
            PriorityMode.Lowest,
            PriorityMode.BelowNormal,
            PriorityMode.Normal,
            PriorityMode.AboveNormal,
            PriorityMode.Highest
        };

        public MainViewModel()
        {
            TaskList = TaskService.List();
            LoadCommand = new RelayCommand(LoadMethod);
            SaveCommand = new RelayCommand(SaveMethod);
            DeleteCommand = new RelayCommand(DeleteMethod);
            UpdateCommand = new RelayCommand(Updatemethod);
            AddRowCommand = new RelayCommand(AddRowMethod);
        }

        public ICommand LoadCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand AddRowCommand { get; private set; }

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

        public StateMode SelectedTaskState
        {
            get { return _selectedTaskState; }
            set
            {
                _selectedTaskState = value;
                RaisePropertyChanged();
            }
        }

        public PriorityMode SelectedTaskPriority
        {
            get { return _selectedTaskPriority; }
            set
            {
                _selectedTaskPriority = value;
                RaisePropertyChanged();
            }
        }

        private void SaveMethod()
        {
            TaskService.Add(_selectedTask);
            LoadMethod();
        }

        private void LoadMethod()
        {
            TaskList = TaskService.List();
            RaisePropertyChanged(() => TaskList);
            GridWindow.Instance.Show();
        }

        private void DeleteMethod()
        {
            TaskService.Delete(_selectedTask);
            LoadMethod();
        }

        private void Updatemethod()
        {
            TaskService.Update(TaskList);
            Messenger.Default.Send(new NotificationMessage("Tasks changed."));
        }

        private void AddRowMethod()
        {
            TaskList.Add(new Task());
            Updatemethod();
        }
    }
}