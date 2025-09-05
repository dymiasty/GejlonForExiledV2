using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class MaxHealthIncrease : CoinPossibility
    {
        public override string Id => "maxHealthIncrease";

        public override string Hint => $"Zwiększono twoje maksymalne zdrowie o {(_multiplier - 1)*100}%.";        

        public override int Weight => 60;

        public override PossibilityType Type => PossibilityType.Positive;


        private const float _multiplier = 1.25f;

        public override bool CanExecute(Player player)
        {
            if (player.MaxHealth >= 65535f)
                return false;

            return true;
        }

        public override void Execute(Player player)
        {
            float oldMaxHealth = player.MaxHealth;
            float newMaxHealth = player.MaxHealth * _multiplier;

            player.MaxHealth = newMaxHealth;
            player.Heal(newMaxHealth - oldMaxHealth);
        }
    }
}
