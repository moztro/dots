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
            // This is already validated per UI input, but this is just to ensure that the rule is still
            // honored during unit testing (or other potential consumers)
            if (Players == null || Players.Count() < Rules.MINIMUM_NUMBER_OF_PLAYERS)
                throw new InvalidOperationException($"You need a minimum of {Rules.MINIMUM_NUMBER_OF_PLAYERS} players to play Dot");

            // Continue playing until there is only 1 player with chips
            while (Players.Count(p => p.Chips > 0) > 1)
            {
                Turns++;
                // Start the turn by going over each player for roll
                foreach (Player player in Players)
                {
                    // If player has no chips cannot roll, skip
                    if (player.Chips < 1)
                        continue;

                    Side rolledSide = player.Roll();

                    switch(rolledSide)
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
