using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class ClearInventory : CoinPossibility
    {
        public override string Id => "clearInventory";

        public override string Hint => "<color=#5c5c5b>Twój ekwipunek został wyczyszczony.</color>";

        public override int Weight => 45;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.ClearInventory();
        }
    }
}
