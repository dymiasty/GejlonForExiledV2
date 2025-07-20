using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Grenade : CoinPossibility
    {
        public override string Id => "grenade";

        public override string Hint => "Dostałeś <color=#82c0c4>granat wybuchowy</color>.";

        public override float HintDuration => 6f;
        
        public override int Weight => 85;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GrenadeHE);
        }
    }
}
