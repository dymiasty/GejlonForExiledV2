using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Collections.Generic;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class InventorySwap : CoinPossibility
    {
        private Player randomPlayer;

        private static readonly string _hint = "Zamieniłeś się ekwipunkiem z losowym graczem.";

        public InventorySwap() : base("invSwap", 30, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            randomPlayer = Plugin.Instance.RandomHumanPlayer();
            
            while (randomPlayer == player)
            {
                randomPlayer = Plugin.Instance.RandomHumanPlayer();
            }

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


            foreach (KeyValuePair<ItemType, ushort> ammo in randomPlayerAmmo)
            {
                player.AddAmmo(ItemToAmmo(ammo.Key), ammo.Value);
            }

            foreach (KeyValuePair<ItemType, ushort> ammo in mainPlayerAmmo)
            {
                randomPlayer.AddAmmo(ItemToAmmo(ammo.Key), ammo.Value);
            }

            foreach (Item item in mainPlayerItems)
            {
                randomPlayer.AddItem(item);
            }

            foreach (Item item in randomPlayerItems)
            {
                player.AddItem(item);
            }

            randomPlayer.ShowHint("Ktoś zamienił się z tobą ekwipunkiem.", 5f);

            randomPlayer = null;
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
