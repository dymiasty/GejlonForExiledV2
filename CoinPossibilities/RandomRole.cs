﻿using Exiled.API.Features;
using Exiled.API.Enums;
using PlayerRoles;
using Exiled.API.Extensions;


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
