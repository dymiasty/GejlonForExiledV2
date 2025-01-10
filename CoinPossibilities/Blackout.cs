using Exiled.API.Enums;
using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Blackout : CoinPossibility
    {
        private static readonly string _hint = "Wyłączyłeś <color=#fcfba7>światła</color> w placówce na 25 sekund.";

        public Blackout() : base("blackout", 35, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Map.TurnOffAllLights(25, ZoneType.Unspecified);
        }
    }
}
