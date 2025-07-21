using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Radio : CoinPossibility
    {
        public override string Id => "radio";

        public override string Hint => "Dostałeś <color=#b6fca7>radio</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 105;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.Radio);
        }
    }
}
