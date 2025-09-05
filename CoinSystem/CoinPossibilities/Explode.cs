using Exiled.API.Features;
using Exiled.API.Features.Items;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Explode : CoinPossibility
    {
        public override string Id => "explode";

        public override string Hint => string.Empty;

        public override int Weight => 55;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE, player);
            grenade.FuseTime = 0.001f;
            grenade.ScpDamageMultiplier = 500f;
            grenade.ConcussDuration = 30f;
            grenade.SpawnActive(player.Position);
        }
    }
}
