using Exiled.API.Features;
using Exiled.API.Enums;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class PocketDimension : CoinPossibility
    {
        public override string Id => "pocketDimension";

        public override string Hint => "Teleportowano cię do <color=#192619>wymiaru łuzowego</color>.";        

        public override int Weight => 40;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.PocketCorroding);
        }
    }
}
