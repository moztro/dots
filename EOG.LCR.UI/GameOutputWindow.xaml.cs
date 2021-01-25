using EOG.LCR.Model;
using EOG.LCR.UI.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace EOG.LCR.UI
{
    /// <summary>
    /// Interaction logic for GameOutputWindow.xaml
    /// </summary>
    public partial class GameOutputWindow : Window
    {
        public GameOutputWindow(List<Game> playedGames)
        {
            InitializeComponent();

            SetupViewModel(playedGames);
        }

        public void SetupViewModel(List<Game> playedGames)
        {
            DataContext = new GameResultsViewModel(playedGames);
        }
    }
}
