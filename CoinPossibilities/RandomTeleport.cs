using Exiled.API.Features;
using System.Collections.Generic;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomTeleport : CoinPossibility
    {
        public override string Id => "randomRoomTeleport";

        public override string Hint => "Teleportowano cię do <color=#fc03a9>losowego pomieszczenia</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType possibilityType => PossibilityType.Mid;

        private readonly List<string> _bannedRooms = new List<string> {
            "EZ_CollapsedTunnel(Clone)",
            "HCZ_Testroom(Clone)",
            "HCZ_Crossroom_Water(Clone)",
            "LCZ_173(Clone)",
            "EZ_Shelter(Clone)",
            "PocketWorld"
        };

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Room roomToTeleportTo = Room.Random();
            
            while (_bannedRooms.Contains(roomToTeleportTo.Name) || _bannedRooms.Contains(roomToTeleportTo.Name) && Map.DecontaminationState == Exiled.API.Enums.DecontaminationState.Start && roomToTeleportTo.Zone == Exiled.API.Enums.ZoneType.LightContainment)
            {
                roomToTeleportTo = Room.Random();
            }

            player.Teleport(roomToTeleportTo);
        }
    }
}
