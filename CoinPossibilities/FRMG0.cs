using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class FRMG0 : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#4f72ff>FR-MG-0</color>.";

        public FRMG0() : base("frmg", 25, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GunFRMG0);
        }
    }
}
