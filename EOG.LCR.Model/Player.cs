using System;

namespace EOG.LCR.Model
{
    /// <summary>
    /// A player in the DOT game
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public int Chips { get; set; } = 3;

        /// <summary>
        /// A player rolls the dice.
        /// </summary>
        /// <returns>A side of the dice</returns>
        public Side Roll()
        {
            int minRollValue = (int)Side.Dot1;
            int maxRollValue = (int)Side.R;
            int roll = new Random().Next(minRollValue, maxRollValue);

            return (Side)roll;
        }
    }
}
