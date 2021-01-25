using EOG.LCR.Model;
using EOG.LCR.UI.Commands;
using System.Windows.Input;

namespace EOG.LCR.UI.ViewModels
{
    public class GameSetupViewModel : BaseViewModel
    {
        public GameSetupViewModel()
        {
            // Set up default values for setup
            NumberOfPlayers = Rules.MINIMUM_NUMBER_OF_PLAYERS;
            NumberOfGames = 1; // at least 1 game to simulate
        }

        #region Properties
        /// <summary>
        /// Amount of players that will play DOT.
        /// Minimum of 3
        /// </summary>
        private int _numberOfPlayers;
        public int NumberOfPlayers
        {
            get => _numberOfPlayers;
            set
            {
                _numberOfPlayers = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Amount of games to be simulated
        /// </summary>
        private int _numberOfGames;
        public int NumberOfGames
        {
            get => _numberOfGames;
            set
            {
                _numberOfGames = value;
                OnPropertyChanged();
            }
        }
        #endregion Properties

        #region Commands
        /// <summary>
        /// A command to execute the game setup
        /// </summary>
        private ICommand _setupGameCommand;
        public ICommand SetupGameCommand
        {
            get => _setupGameCommand ??= new SetupGameCommand();
        }
        #endregion Commands
    }
}
