using Exiled.API.Features;
using Exiled.API.Enums;
using PlayerRoles;
using Exiled.API.Extensions;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomRole : CoinPossibility
    {
        public override string Id => "randomRole";

        public override string Hint => "Losowo zmieniono twoją rolę.";

        public override float HintDuration => 6f;

        public override int Weight => 45;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            RoleTypeId roleToSet = Plugin.Instance.RandomRole();

            while (roleToSet == player.Role || roleToSet == RoleTypeId.Scp0492)
            {
                roleToSet = Plugin.Instance.RandomRole();
            }

            if (Plugin.Instance.GetLivingSCPs().Count == 0)
            {
                while (roleToSet == RoleTypeId.Scp079)
                {
                    roleToSet = Plugin.Instance.RandomRole();
                }
            }

            player.Role.Set(roleToSet, SpawnReason.ItemUsage, RoleSpawnFlags.AssignInventory);

            if (roleToSet.IsScp())
            {
                player.MaxHealth /= 2;
            }
        }
    }
}
