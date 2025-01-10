using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class EyesSevered : CoinPossibility
    {
        private static readonly string _hint = 
            "Wyobraziłeś sobie twarz Nei'a." +
            "\nTak cię wykręciło że wyrwałeś sobie oczy.";

        public EyesSevered() : base("eyesSevered", 25, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.SeveredEyes);
        }
    }
}
