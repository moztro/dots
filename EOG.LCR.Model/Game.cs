using System;
using System.Collections.Generic;
using System.Linq;

namespace EOG.LCR.Model
{
    /// <summary>
    /// Represents a DOT game to be played
    /// </summary>
    public class Game
    {
        private const int _minNumberOfPlayers = 3;

        /// <summary>
        /// Number of turns played
        /// </summary>
        public int Turns { get; private set; }

        /// <summary>
        /// Number of players in the game
        /// </summary>
        public List<Player> Players { get; set; }

        public Game(List<Player> players)
        {
            Players = players;
        }

        /// <summary>
        /// Runs a DOT game
        /// </summary>
        public void Start()
        {
            if (Players == null || Players.Count() < _minNumberOfPlayers)
                throw new InvalidOperationException($"You need a minimum of {_minNumberOfPlayers} players to play Dot");

            // Continue playing until there is only 1 player with chips
            while (Players.Count(p => p.Chips > 0) > 1)
            {
                Turns++;
                // Start the turn by going over each player for roll
                foreach (Player player in Players)
                {
                    Side rolledSide = player.Roll();

                    switch (rolledSide)
                    {
                        case Side.Dot1:
                        case Side.Dot2:
                        case Side.Dot3:
                            // Keep the chips
                            break;
                        case Side.L:
                            // Pass a chip to the Left player
                            player.Chips--;
                            Players[(Players.IndexOf(player) + 1) % Players.Count()].Chips++;
                            break;
                        case Side.R:
                            // Pass a chip to the right player
                            player.Chips--;
                            Players[Players.IndexOf(player) - 1].Chips++;
                            break;
                        case Side.C:
                            // Put a chip on the center
                            player.Chips--;
                            break;
                        default: break;
                    }
                }
            }

            // TO-DO: Possible enhancement, to show the winner for each game, not a req for the simulation now
            // Get the winner (the only player with chips left)
            // Player winner = Players.First(p => p.Chips > 0);
            //Console.WriteLine($"Winner is {winner.Name}. Congratulations!");
        }
    }
}
