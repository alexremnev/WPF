using System;
using GalaSoft.MvvmLight;

namespace Task_Scheduler.Models
{
    [Serializable]
    public class Task : ObservableObject
    {
        private string title;
        private string description;
        private StateMode state;
        private DateTime startDate;
        private DateTime endDate;
        private PriorityMode priority;

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

        public StateMode State
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
            set
            {
                Set(() => EndDate, ref endDate, value);
            }
        }

        public PriorityMode Priority
        {
            get { return priority; }
            set { Set(() => Priority, ref priority, value); }
        }
    }
}