using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class EyesSevered : CoinPossibility
    {
        public override string Id => "eyesSevered";

        public override string Hint => "Wyrwałeś sobie oczy ze stresu.";

        public override float HintDuration => 6f;

        public override int Weight => 55;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.SeveredEyes);
        }
    }
}
