using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Radio : CoinPossibility
    {
        public override string Id => "radio";

        public override string Hint => "Dostałeś <color=#b6fca7>radio</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 100;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.Radio);
        }
    }
}
