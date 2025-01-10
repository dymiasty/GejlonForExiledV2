using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Grenade : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#82c0c4>granat wybuchowy</color>.";

        public Grenade() : base("grenade", 25, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GrenadeHE);
        }
    }
}
