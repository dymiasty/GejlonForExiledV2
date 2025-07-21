using Exiled.API.Enums;
using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Blackout : CoinPossibility
    {
        public override string Id => "blackout";

        public override string Hint => "Wyłączyłeś <color=#fcfba7>światła</color> w placówce na 25 sekund.";

        public override float HintDuration => 6f;

        public override int Weight => 60;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Map.TurnOffAllLights(25, ZoneType.Unspecified);
        }
    }
}
