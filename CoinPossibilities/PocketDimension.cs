using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class PocketDimension : CoinPossibility
    {
        private static readonly string _hint = "Teleportowano cię do <color=#192619>wymiaru łuzowego</color>.";

        public PocketDimension() : base("pocketDim", 25, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.PocketCorroding);
        }
    }
}
