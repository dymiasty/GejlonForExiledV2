using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Flashlight : CoinPossibility
    {
        public override string Id => "flashlight";

        public override string Hint => "Dostałeś <color=#fff896>latarkę</color>.";

        public override int Weight => 85;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.Flashlight);
        }
    }
}
