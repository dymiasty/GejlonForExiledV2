using Exiled.API.Features;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class WarheadDetonate : CoinPossibility
    {
        public override string Id => "warheadDetonate";

        public override string Hint => "<color=#b8541a>Wysadziłeś placówkę</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 9;

        public override PossibilityType possibilityType => PossibilityType.Mid;

        public bool CanDetonate = false;

        public override bool CanExecute(Player player)
        {
            return CanDetonate;
        }

        public override void Execute(Player player)
        {
            Warhead.Detonate();
        }
    }
}
