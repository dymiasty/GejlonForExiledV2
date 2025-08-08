using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class OneHp : CoinPossibility
    {
        public override string Id => "oneHP";

        public override string Hint => "Twoje <color=#fc0328>zdrowie</color> zostało zmniejszone do <color=#fc0328>1</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 35;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Health = 1f;
        }
    }
}
