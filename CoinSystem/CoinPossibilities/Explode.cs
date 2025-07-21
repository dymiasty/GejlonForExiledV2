using Exiled.API.Features;
using Exiled.API.Features.Items;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Explode : CoinPossibility
    {
        public override string Id => "explode";

        public override string Hint => string.Empty;

        public override float HintDuration => 6f;

        public override int Weight => 55;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE, player);
            grenade.FuseTime = 0.001f;
            grenade.ScpDamageMultiplier = 25f;
            grenade.ConcussDuration = 30f;
            grenade.SpawnActive(player.Position);
        }
    }
}
