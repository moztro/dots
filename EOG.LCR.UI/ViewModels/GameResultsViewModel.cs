using EOG.LCR.Model;
using System.Collections.Generic;
using System.Linq;

namespace EOG.LCR.UI.ViewModels
{
    public class GameResultsViewModel : BaseViewModel
    {
        public GameResultsViewModel(List<Game> playedGames)
        {
            PlayedGames = playedGames;
        }

        public IEnumerable<Game> PlayedGames { get; set; }

        public int ShortestLengthGame { get => PlayedGames.Min(g => g.Turns); }

        public int LongestLengthGame { get => PlayedGames.Max(g => g.Turns); }

        public int AverageLengthGame { get => (int)PlayedGames.Average(g => g.Turns); }
    }
}
