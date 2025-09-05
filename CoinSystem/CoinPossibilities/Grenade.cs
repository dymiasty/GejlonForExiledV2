using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Grenade : CoinPossibility
    {
        public override string Id => "grenade";

        public override string Hint => "Dostałeś <color=#82c0c4>granat wybuchowy</color>.";        
        
        public override int Weight => 80;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GrenadeHE);
        }
    }
}
