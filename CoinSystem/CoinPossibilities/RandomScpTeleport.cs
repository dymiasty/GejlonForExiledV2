using Exiled.API.Features;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomScpTeleport : CoinPossibility
    {
        public override string Id => "randomScpTeleport";

        public override string Hint => "Teleportowano cię do <color=#a30f0f>losowego SCP</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 50;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player)
        {
            if (Util.GetLivingSCPs().Count != 0) 
                return true;

            if (Util.GetLivingSCPs().Count == 1 && Util.GetLivingSCPs().ToList().ElementAt(0).Role == RoleTypeId.Scp079)
                return false;

            return false;
        }

        public override void Execute(Player player)
        {
            List<Player> livingScps = Util.GetLivingSCPs();

            Player scp = livingScps.ElementAt(Random.Range(0, livingScps.Count));

            while (scp.Role == RoleTypeId.Scp079)
            {
                scp = livingScps.ElementAt(Random.Range(0, livingScps.Count));
            }

            player.Position = scp.Position;
        }
    }
}
