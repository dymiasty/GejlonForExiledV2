using Exiled.API.Features;
using PlayerRoles;

namespace GejlonForExiledV2.ReviveSystem
{
    public class DeadPlayerData
    {
        public RoleTypeId roleType;
        public Ragdoll LatestRagdoll;
        public int UsedMedkits = 0;
    }
}
