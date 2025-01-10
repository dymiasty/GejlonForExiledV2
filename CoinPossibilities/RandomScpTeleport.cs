using Exiled.API.Features;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp079.Map;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomScpTeleport : CoinPossibility
    {
        private static readonly string _hint = "Teleportowano cię do <color=#a30f0f>losowego SCP</color>.";

        public RandomScpTeleport() : base("randomScpTp", 30, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player)
        {
            if (Plugin.Instance.GetLivingSCPs().Count != 0) 
                return true;

            if (Plugin.Instance.GetLivingSCPs().Count == 1 && Plugin.Instance.GetLivingSCPs().ToList().ElementAt(0).Role == RoleTypeId.Scp079)
                return false;

            return false;
        }

        public override void Execute(Player player)
        {
            List<Player> livingScps = Plugin.Instance.GetLivingSCPs();

            Player scp = livingScps.ElementAt(Random.Range(0, livingScps.Count));

            while (scp.Role == RoleTypeId.Scp079)
            {
                scp = livingScps.ElementAt(Random.Range(0, livingScps.Count));
            }

            player.Position = scp.Position;
        }
    }
}
