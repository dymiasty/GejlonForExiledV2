using Exiled.API.Features;
using Exiled.API.Enums;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class EscapeTeleport : CoinPossibility
    {
        public override string Id => "escapeTeleport";

        public override string Hint => "Zostałeś teleportowany do wyjścia z placówki.";

        public override float HintDuration => 6f;

        public override int Weight => 65;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Teleport(DoorType.EscapeSecondary);
        }
    }
}
