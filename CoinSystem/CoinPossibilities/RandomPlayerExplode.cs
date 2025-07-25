using Exiled.API.Features;
using Exiled.API.Features.Items;
using PlayerRoles;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomPlayerExplode : CoinPossibility
    {
        public override string Id => "randomPlayerExplode";

        public override string Hint => "Wysadziłeś losową osobę.";

        public override float HintDuration => 6f;

        public override int Weight => 25;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE, player);
            grenade.FuseTime = 0.001f;
            grenade.ScpDamageMultiplier = 500f;
            grenade.ConcussDuration = 30f;

            Player playerToExplode = Plugin.Instance.RandomAlivePlayer();

            while (playerToExplode.Role == RoleTypeId.Scp079) {
                playerToExplode = Plugin.Instance.RandomAlivePlayer();
            }

            grenade.SpawnActive(playerToExplode.Position);
        }
    }
}
