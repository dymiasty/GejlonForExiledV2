using Exiled.API.Features;
using Exiled.API.Enums;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class EscapeTeleport : CoinPossibility
    {
        private static readonly string _hint = "Zostałeś teleportowany do wyjścia z placówki.";

        public EscapeTeleport() : base("escapeTeleport", 35, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Teleport(DoorType.EscapeSecondary);
        }
    }
}
