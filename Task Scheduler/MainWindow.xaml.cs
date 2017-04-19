namespace Task_Scheduler
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            instance = this;
            GridWindow.Instance.Show(); //todo
            instance.Close(); //todo
        }

        private static MainWindow instance;
        public static MainWindow Instance => instance ?? (instance = new MainWindow());
    }
}