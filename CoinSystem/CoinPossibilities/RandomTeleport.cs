using Exiled.API.Features;
using GejlonForExiledV2.General;
using System.Collections.Generic;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomTeleport : CoinPossibility
    {
        public override string Id => "randomRoomTeleport";

        public override string Hint => "Teleportowano cię do <color=#fc03a9>losowego pomieszczenia</color>.";

        public override int Weight => 45;

        public override PossibilityType Type => PossibilityType.Mid;


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
