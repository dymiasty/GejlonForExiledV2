﻿using Exiled.API.Features;
using Exiled.API.Features.Items;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Explode : CoinPossibility
    {
        private static readonly string _hint = string.Empty;

        public Explode() : base("explode", 20, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE, player);
            grenade.FuseTime = 0.001f;
            grenade.ScpDamageMultiplier = 25;
            grenade.ConcussDuration = 30f;
            grenade.SpawnActive(player.Position);
        }
    }
}
