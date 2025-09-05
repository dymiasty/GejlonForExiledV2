using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Flashbang : CoinPossibility
    {
        public override string Id => "flashbang";

        public override string Hint => "Dostałeś <color=#a0faf7>granat błyskowy</color>.";

        public override int Weight => 75;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GrenadeFlash);
        }
    }
}
