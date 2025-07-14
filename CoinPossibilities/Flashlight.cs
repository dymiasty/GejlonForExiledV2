using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Flashlight : CoinPossibility
    {
        public override string Id => "flashlight";

        public override string Hint => "Dostałeś <color=#fff896>latarkę</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 90;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.Flashlight);
        }
    }
}
