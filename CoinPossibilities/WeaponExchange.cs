﻿using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class WeaponExchange : CoinPossibility
    {
        private static readonly string _hint = "Udałeś się do lombardu. Zamieniłeś wszystkie bronie na monety.";

        public WeaponExchange() : base("weaponExchange", 33, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player)
        {
            foreach (Item item in player.Items.ToList())
            {
                if (item.IsWeapon)
                    return true;
            }


            return false;
        }

        public override void Execute(Player player)
        {
            foreach (Item item in player.Items.ToList())
            {
                if (item.IsWeapon)
                {
                    player.RemoveItem(item);
                    player.AddItem(ItemType.Coin);
                }
            }
        }
    }
}
