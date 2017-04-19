using Xceed.Wpf.Toolkit;

namespace Task_Scheduler
{
    public partial class GridWindow
    {
        private GridWindow()
        {
            InitializeComponent();
        }

        private static GridWindow instance;
        public static GridWindow Instance => instance ?? (instance = new GridWindow());
    }
}