using EOG.LCR.Model;
using EOG.LCR.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace EOG.LCR.UI.Commands
{
    public class SetupGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var setup = (GameSetupViewModel)parameter;

            // If input is invalid, do nothing
            if (!(setup.IsNumberOfGamesValid && setup.IsNumberOfPlayersValid))
                return;

            // Create the required amount of players for simulation
            var players = new List<Player>();
            for (int i = 0, j = setup.NumberOfPlayers; i < j; i++)
            {
                players.Add(new Player { Name = $"Player {i + 1}" });
            }

            // Create each simulated game, run it, and add it to the 
            // collection of played games
            var games = new List<Game>();
            for (int i = 0, j = setup.NumberOfGames; i < j; i++)
            {
                var dotgame = new Game(players);
                dotgame.Start();

                games.Add(dotgame);

                // After a game is finished, restart each player chips
                foreach (var player in players)
                    player.Chips = Rules.NUMBER_OF_INITIAL_CHIPS;
            }

            var resultsWindow = new GameOutputWindow(games);
            resultsWindow.ShowDialog();
        }
    }
}
