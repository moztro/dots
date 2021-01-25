namespace EOG.LCR.Model
{
    /// <summary>
    /// Represents a 6-sided dice marked with following letters,
    /// each on one side of the dice L, C, and R. The other 3
    /// sides of each dice are marked with a dot.
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// All six sides for the dice
        /// </summary>
        private Side[] _side = new Side[]
        {
            Side.Dot1,
            Side.Dot2,
            Side.Dot3,
            Side.L,
            Side.C,
            Side.R
        };

        public Side Min => _side[0];
        public Side Max => _side[_side.Length - 1];

        public Side this[int index]
        {
            get => _side[index];
            private set => _side[index] = value;
        }
    }
}
