using EOG.LCR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EOG.LCR.Tests
{
    public class GamePlayTests
    {
        List<Player> _players = new List<Player>
        {
            new Player { Name = "John" },
            new Player { Name = "Brad" },
            new Player { Name = "Peter" }
        };

        [Fact]
        public void RunABasicGame_Test()
        {
            // Create a dot game with players
            var dotgame = new Game(_players);

            // Assert the players for the game
            int expectedNumberOfPlayers = _players.Count();
            Assert.True(dotgame.Players.Any());
            Assert.Equal(expectedNumberOfPlayers, dotgame.Players.Count());

            // let's play
            dotgame.Start();

            // Assert that at least 1 turn was played
            Assert.True(dotgame.Turns > 0);
        }

        [Fact]
        public void RunAGameWithLessThanThreePlayersShouldThrowException_Test()
        {
            // Remove the first player, so there are only 2 players
            _players.RemoveAt(0);
            // Create a dot game with less than 3 players
            var dotgame = new Game(_players);

            // Assert the players for the game
            int expectedNumberOfPlayers = _players.Count();
            Assert.True(dotgame.Players.Any());
            Assert.Equal(expectedNumberOfPlayers, dotgame.Players.Count());

            // Trying to start a game should throw an exception,
            // cause minimum amount of players is 3
            Assert.Throws<InvalidOperationException>(() => dotgame.Start());
        }

        [Fact]
        public void RunAGameWithLessThanThreePlayers_ThenAddMorePlayers_Test()
        {
            // Remove the first player, so there are only 2 players
            _players.RemoveAt(0);
            // Create a dot game with less than 3 players
            var dotgame = new Game(_players);

            // Assert the players for the game
            int expectedNumberOfPlayers = _players.Count();
            Assert.True(dotgame.Players.Any());
            Assert.Equal(expectedNumberOfPlayers, dotgame.Players.Count());

            // Trying to start a game should throw an exception,
            // cause minimum amount of players is 3
            Assert.Throws<InvalidOperationException>(() => dotgame.Start());

            // Add one more player, so the game now has 3 participants
            dotgame.Players.Add(new Player { Name = "Daniel" });
            dotgame.Start();

            // Assert that at least 1 turn was played
            Assert.True(dotgame.Turns > 0);
        }
    }
}
