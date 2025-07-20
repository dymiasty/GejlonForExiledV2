using Exiled.API.Features;
using Exiled.API.Enums;
using UnityEngine;
using System.Collections.Generic;
using Exiled.API.Features.Items;
using System.Linq;
using PlayerRoles;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class LifeSwap : CoinPossibility
    {
        public override string Id => "lifeSwap";

        public override string Hint => "Zamieniłeś się życiami z losowym graczem.";

        public override float HintDuration => 6f;

        public override int Weight => 45;

        public override PossibilityType possibilityType => PossibilityType.Mid;

        public override bool CanExecute(Player player)
        {
            int alivePlayers = 0;

            foreach (Player playerr in Player.List.ToList())
            {
                if (playerr.IsAlive)
                    alivePlayers++;
            }

            if (alivePlayers <= 1)
                return false;

            return true;
        }

        public override void Execute(Player player)
        {
            Player randomPlayer = Plugin.Instance.RandomAlivePlayer();

            while (randomPlayer == player)
            {
                randomPlayer = Plugin.Instance.RandomAlivePlayer();
            }

            Vector3 randomPlayerPos = new Vector3(randomPlayer.Position.x, randomPlayer.Position.y, randomPlayer.Position.z);

            RoleTypeId randomPlayerRole = randomPlayer.Role;


            List<Item> randomPlayerItems = new List<Item>();
            List<Item> mainPlayerItems = new List<Item>();

            Dictionary<ItemType, ushort> randomPlayerAmmo = new Dictionary<ItemType, ushort>(randomPlayer.Ammo);
            Dictionary<ItemType, ushort> mainPlayerAmmo = new Dictionary<ItemType, ushort>(player.Ammo);

            foreach (Item item in randomPlayer.Items)
            {
                randomPlayerItems.Add(item);
            }


            foreach (Item item in player.Items)
            {
                mainPlayerItems.Add(item);
            }

            randomPlayer.ClearInventory(false);
            player.ClearInventory(false);

            //----------------------------------------------------------------

            randomPlayer.Role.Set(player.Role, SpawnReason.ItemUsage, RoleSpawnFlags.None);
            randomPlayer.Position = player.Position;

            foreach (KeyValuePair<ItemType, ushort> ammo in mainPlayerAmmo)
            {
                randomPlayer.AddAmmo(ItemToAmmo(ammo.Key), ammo.Value);
            }

            foreach (Item item in mainPlayerItems)
            {
                randomPlayer.AddItem(item);
            }

            player.Role.Set(randomPlayerRole, SpawnReason.ItemUsage, RoleSpawnFlags.None);
            player.Position = randomPlayerPos;

            foreach (KeyValuePair<ItemType, ushort> ammo in randomPlayerAmmo)
            {
                player.AddAmmo(ItemToAmmo(ammo.Key), ammo.Value);
            }

            foreach (Item item in randomPlayerItems)
            {
                player.AddItem(item);
            }

            randomPlayer.ShowHint("Gracz " + player.Nickname + " zamienił się z tobą.", 6f);
        }


        private AmmoType ItemToAmmo(ItemType item)
        {
            switch (item)
            {
                default:
                    return AmmoType.None;

                case ItemType.Ammo12gauge:
                    return AmmoType.Ammo12Gauge;
                case ItemType.Ammo556x45:
                    return AmmoType.Nato556;
                case ItemType.Ammo44cal:
                    return AmmoType.Ammo44Cal;
                case ItemType.Ammo762x39:
                    return AmmoType.Nato762;
                case ItemType.Ammo9x19:
                    return AmmoType.Nato9;
            }
        }
    }
}
