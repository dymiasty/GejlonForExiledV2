using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class EyesSevered : CoinPossibility
    {
        public override string Id => "eyesSevered";

        public override string Hint =>
            "Wyobraziłeś sobie twarz Nei'a." +
            "\nTak cię wykręciło że wyrwałeś sobie oczy.";

        public override float HintDuration => 6f;

        public override int Weight => 75;

        public override PossibilityType possibilityType => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.SeveredEyes);
        }
    }
}
