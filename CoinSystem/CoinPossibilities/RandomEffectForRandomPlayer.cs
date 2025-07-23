using Exiled.API.Features;
using PlayerRoles;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomEffectForRandomPlayer : CoinPossibility
    {
        public override string Id => "randomEffectForRandomPlayer";

        public override string Hint => "Przyznałeś losowemu graczowi losowy efekt na 10 sekund.";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Player randomPlayer = Plugin.Instance.RandomAlivePlayer();

            while (randomPlayer.Role == RoleTypeId.Scp079 || randomPlayer == player)
            {
                randomPlayer = Plugin.Instance.RandomAlivePlayer();
            }

            randomPlayer.ApplyRandomEffect(duration: 10f);
        }
    }
}
