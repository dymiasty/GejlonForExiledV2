using Exiled.API.Features;
using Exiled.API.Enums;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class HandsSevered : CoinPossibility
    {
        private static readonly string _hint = "Uciąłeś sobie ręce monetą.";

        public HandsSevered() : base("handsSevered", 25, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.EnableEffect(EffectType.SeveredHands);
        }
    }
}
