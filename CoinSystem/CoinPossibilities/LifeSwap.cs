using Exiled.API.Features;
using Exiled.API.Enums;
using UnityEngine;
using System.Collections.Generic;
using Exiled.API.Features.Items;
using System.Linq;
using PlayerRoles;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class LifeSwap : CoinPossibility
    {
        public override string Id => "lifeSwap";

        public override string Hint => "Zamieniłeś się życiami z losowym graczem.";

        public override float HintDuration => 6f;

        public override int Weight => 40;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player)
        {
            int alivePlayers = 0;

            foreach (Player playerr in Player.List.ToList())
            {
                if (playerr.IsAlive)
                    alivePlayers++;

                if (alivePlayers > 1)
                    return true;
            }

            return false;
        }

        public override void Execute(Player player)
        {
            Player randomPlayer = Util.RandomAlivePlayer();

            while (randomPlayer == player)
            {
                randomPlayer = Util.RandomAlivePlayer();
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
                randomPlayer.AddAmmo(Util.ItemToAmmo(ammo.Key), ammo.Value);
            }

            foreach (Item item in mainPlayerItems)
            {
                randomPlayer.AddItem(item);
            }

            player.Role.Set(randomPlayerRole, SpawnReason.ItemUsage, RoleSpawnFlags.None);
            player.Position = randomPlayerPos;

            foreach (KeyValuePair<ItemType, ushort> ammo in randomPlayerAmmo)
            {
                player.AddAmmo(Util.ItemToAmmo(ammo.Key), ammo.Value);
            }

            foreach (Item item in randomPlayerItems)
            {
                player.AddItem(item);
            }

            randomPlayer.ShowHint("Gracz " + player.Nickname + " zamienił się z tobą.", 6f);
        }
    }
}
