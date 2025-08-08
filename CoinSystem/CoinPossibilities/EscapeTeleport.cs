using Exiled.API.Features;
using Exiled.API.Enums;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class EscapeTeleport : CoinPossibility
    {
        public override string Id => "escapeTeleport";

        public override string Hint => "Zostałeś teleportowany do wyjścia z placówki.";

        public override float HintDuration => 6f;

        public override int Weight => 60;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Teleport(DoorType.EscapeSecondary);
        }
    }
}
