using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Flashbang : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#a0faf7>granat błyskowy</color>.";

        public Flashbang() : base("flashbang", 15, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GrenadeFlash);
        }
    }
}
