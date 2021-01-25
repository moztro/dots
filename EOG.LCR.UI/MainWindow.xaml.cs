using EOG.LCR.UI.ViewModels;
using System.Windows;

namespace EOG.LCR.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetupViewModel();
        }

        public void SetupViewModel()
        {
            DataContext = new GameSetupViewModel();
        }
    }
}
