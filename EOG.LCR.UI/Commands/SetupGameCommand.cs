using EOG.LCR.Model;
using EOG.LCR.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
            var simulator = (GameSetupViewModel)parameter;

            var gameThread = new Thread(new ThreadStart(() =>
            {
                // If input is invalid, do nothing
                if (!(simulator.IsNumberOfGamesValid && simulator.IsNumberOfPlayersValid))
                    return;

                simulator.IsRunning = true;

                // Create the required amount of players for simulation
                var players = new List<Player>();
                for (int i = 0, j = simulator.NumberOfPlayers; i < j; i++)
                {
                    players.Add(new Player { Name = $"Player {i + 1}" });
                }

                // Create each simulated game, run it, and add it to the 
                // collection of played games
                var games = new List<Game>();
                for (int i = 0, j = simulator.NumberOfGames; i < j; i++)
                {
                    var dotgame = new Game(players);
                    dotgame.Start();

                    games.Add(dotgame);
                    simulator.GamesFinished = i + 1;

                    // After a game is finished, restart each player chips
                    foreach (var player in players)
                        player.Chips = Rules.NUMBER_OF_INITIAL_CHIPS;
                }

                simulator.IsRunning = false;

                var resultsWindow = new GameOutputWindow(games);
                resultsWindow.ShowDialog();
            }));

            // Put simulation on an single thread, since have dependant UI components
            gameThread.SetApartmentState(ApartmentState.STA);
            gameThread.IsBackground = true;
            gameThread.Start();
        }
    }
}
