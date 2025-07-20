using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Flashbang : CoinPossibility
    {
        public override string Id => "flashbang";

        public override string Hint => "Dostałeś <color=#a0faf7>granat błyskowy</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.GrenadeFlash);
        }
    }
}
