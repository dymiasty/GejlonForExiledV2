using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class FRMG0 : CoinPossibility
    {
        public override string Id => "frmg";

        public override string Hint => "Dostałeś <color=#4f72ff>FR-MG-0</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GunFRMG0);
        }
    }
}
