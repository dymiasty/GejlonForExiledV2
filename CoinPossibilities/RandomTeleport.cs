using Exiled.API.Features;
using System.Collections.Generic;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomTeleport : CoinPossibility
    {
        private static readonly string _hint = "Teleportowano cię do <color=#fc03a9>losowego pomieszczenia</color>.";

        public RandomTeleport() : base("randomTeleport", 30, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        private List<string> _bannedRooms = new List<string> { 
            "EZ_CollapsedTunnel(Clone)",
            "HCZ_Testroom(Clone)",
            "HCZ_Crossroom_Water(Clone)",
            "LCZ_173(Clone)",
            "EZ_Shelter(Clone)",
            "PocketWorld"
        };

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
