using System.Collections.Generic;

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
        }
    }
}
