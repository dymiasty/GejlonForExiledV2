using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Defecate : CoinPossibility
    {
        public override string Id => "defecate";

        public override string Hint => "Wypróżniłeś się.";

        public override float HintDuration => 6f;

        public override int Weight => 65;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.PlaceTantrum();
        }
    }
}
