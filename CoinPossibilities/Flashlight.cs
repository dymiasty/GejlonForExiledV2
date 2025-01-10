using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Flashlight : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#fff896>latarkę</color>.";

        public Flashlight() : base("flashlight", 15, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.Flashlight);
        }
    }
}
