using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class PocketDimension : CoinPossibility
    {
        public override string Id => "pocketDimension";

        public override string Hint => "Teleportowano cię do <color=#192619>wymiaru łuzowego</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 45;

        public override PossibilityType possibilityType => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.PocketCorroding);
        }
    }
}
