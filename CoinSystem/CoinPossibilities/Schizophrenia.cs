using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Schizophrenia : CoinPossibility
    {
        public override string Id => "schizophrenia";

        public override string Hint => "Dostałeś schizofreni.";

        public override float HintDuration => 6f;

        public override int Weight => 45;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) => true;

        public override void Execute(Player player)
        {
            player.EnableEffect(Exiled.API.Enums.EffectType.AmnesiaVision);
        }
    }
}
