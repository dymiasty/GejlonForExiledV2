using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class AntiCola : CoinPossibility
    {
        private static readonly string _hint = "<color=#871060>D#?t%ł@ś c0^a-$#lę</color>.";

        public AntiCola() : base("antiCola", 15, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.AntiSCP207);
        }
    }
}
