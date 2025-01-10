using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;
using Random = UnityEngine.Random;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomPlayerExplode : CoinPossibility
    {
        private static readonly string _hint = "Wysadziłeś losową osobę.";

        public RandomPlayerExplode() : base("randomPlayerExplode", 25, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE, player);
            grenade.FuseTime = 0.001f;
            grenade.ScpDamageMultiplier = 25;
            grenade.ConcussDuration = 30f;
            grenade.SpawnActive(Plugin.Instance.RandomAlivePlayer().Position);
        }
    }
}
