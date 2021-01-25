using EOG.LCR.Model;
using EOG.LCR.UI.Commands;
using System.Windows;
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

            // Hide error messages at the start
            NumberOfPlayersErrorMessageVisibility = Visibility.Hidden;
            NumberOfGamesErrorMessageVisibility = Visibility.Hidden;

            IsRunning = false;
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
                IsNumberOfPlayersValid = value >= Rules.MINIMUM_NUMBER_OF_PLAYERS;
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
                IsNumberOfGamesValid = value > 0;
                _numberOfGames = value;
                OnPropertyChanged();
            }
        }

        private int _gamesFinished;
        public int GamesFinished
        {
            get => _gamesFinished;
            set
            {
                _gamesFinished = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Indicate if the simulation is running
        /// </summary>
        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;

                // Show or hide the loading message
                LoadingMessageVisibility = value ? Visibility.Visible : Visibility.Hidden;
                OnPropertyChanged(nameof(LoadingMessageVisibility));

                // Enable or disable the submit button
                IsSubmitButtonEnabled = !value;
                OnPropertyChanged(nameof(IsSubmitButtonEnabled));

                // Enable or disable input fields
                IsInputEnabled = !value;
                OnPropertyChanged(nameof(IsInputEnabled));
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

        #region Validation Messages Props
        private bool _isNumberOfPlayersValid;
        public bool IsNumberOfPlayersValid
        {
            get => _isNumberOfPlayersValid;
            set
            {
                _isNumberOfPlayersValid = value;
                NumberOfPlayersErrorMessageVisibility = value ? Visibility.Hidden : Visibility.Visible;
                OnPropertyChanged(nameof(NumberOfPlayersErrorMessageVisibility));
            }
        }

        private bool _isNumberOfGamesValid;
        public bool IsNumberOfGamesValid
        {
            get => _isNumberOfGamesValid;
            set
            {
                _isNumberOfGamesValid = value;
                NumberOfGamesErrorMessageVisibility = value ? Visibility.Hidden : Visibility.Visible;
                OnPropertyChanged(nameof(NumberOfGamesErrorMessageVisibility));
            }
        }
        #endregion Validation Messages Props

        #region UI State Properties

        private Visibility _numberOfGamesErrorMessageVisibility;
        public Visibility NumberOfGamesErrorMessageVisibility
        {
            get => _numberOfGamesErrorMessageVisibility;
            set
            {
                _numberOfGamesErrorMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _numberOfPlayersErrorMessageVisibility;
        public Visibility NumberOfPlayersErrorMessageVisibility
        {
            get => _numberOfPlayersErrorMessageVisibility;
            set
            {
                _numberOfPlayersErrorMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _loadingMessageVisibility;
        public Visibility LoadingMessageVisibility
        {
            get => _loadingMessageVisibility;
            set
            {
                _loadingMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        private bool _isSubmitButtonEnabled;
        public bool IsSubmitButtonEnabled
        {
            get => _isSubmitButtonEnabled;
            set
            {
                _isSubmitButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool _isInputEnabled;
        public bool IsInputEnabled
        {
            get => _isInputEnabled;
            set
            {
                _isInputEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion UI State Properties
    }
}
