﻿using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class WeaponExchange : CoinPossibility
    {
        public override string Id => "weaponExchange";

        public override string Hint => "Udałeś się do lombardu. Zamieniłeś wszystkie bronie na monety.";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType Type => PossibilityType.Negative;

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
