using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.API.Enums;
using PlayerRoles;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomRole : CoinPossibility
    {
        private static readonly string _hint = "Losowo zmieniono twoją rolę.";

        public RandomRole() : base("randomRole", 25, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            RoleTypeId roleToSet = Plugin.Instance.RandomRole();

            while (roleToSet == player.Role || roleToSet == RoleTypeId.Scp0492)
            {
                roleToSet = Plugin.Instance.RandomRole();
            }

            player.Role.Set(roleToSet, SpawnReason.ItemUsage, RoleSpawnFlags.AssignInventory);
        }
    }
}
