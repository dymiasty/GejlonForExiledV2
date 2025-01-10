using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class HealFor50 : CoinPossibility
    {
        private static readonly string _hint = "Zostałeś uleczony o <color=green>50 HP</color>.";

        public HealFor50() : base("heal50", 15, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Heal(50f, false);
        }
    }
}
