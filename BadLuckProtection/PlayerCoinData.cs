namespace GejlonForExiledV2.BadLuckProtection
{
    public class PlayerCoinData
    {
        public int TotalRolls { get; set; } = 0;

        public int PositiveRolls { get; set; } = 0;
        public int NegativeRolls { get; set; } = 0;

        public int NegativeStreak { get; set; } = 0;
        public int PositiveSinceLastNegative {  get; set; } = 0;
    }
}
