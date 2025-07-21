using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class SizeReduce : CoinPossibility
    {
        public override string Id => "sizeReduce";

        public override string Hint => "Zostałeś zmniejszony.";

        public override float HintDuration => 6f;

        public override int Weight => 75;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Scale *= 0.75f;
        }
    }
}
