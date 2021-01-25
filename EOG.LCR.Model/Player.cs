using System;

namespace EOG.LCR.Model
{
    /// <summary>
    /// A player in the DOT game
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public int Chips { get; set; } = Rules.NUMBER_OF_INITIAL_CHIPS;

        /// <summary>
        /// A player rolls the dice.
        /// </summary>
        /// <returns>A side of the dice</returns>
        public Side Roll()
        {
            var dice = new Dice();
            int minRollValue = (int)dice.Min;
            int maxRollValue = (int)dice.Max;
            int roll = new Random().Next(minRollValue, maxRollValue);

            return (Side)roll;
        }
    }
}
