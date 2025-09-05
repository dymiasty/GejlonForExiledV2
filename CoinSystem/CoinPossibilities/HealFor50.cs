using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class HealFor50 : CoinPossibility
    {
        public override string Id => "heal50";

        public override string Hint => "Zostałeś uleczony o <color=green>50 HP</color>.";        

        public override int Weight => 100;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Heal(50f, false);
        }
    }
}
