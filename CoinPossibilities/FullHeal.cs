using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class FullHeal : CoinPossibility
    {
        private static readonly string _hint = "Zostałeś uleczony <color=green>do pełna</color>.";

        public FullHeal() : base("fullHeal", 20, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Heal(player.MaxHealth, false);
        }
    }
}
