using Exiled.API.Features;
using GejlonForExiledV2.General;
using PlayerRoles;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomEffectForRandomPlayer : CoinPossibility
    {
        public override string Id => "randomEffectForRandomPlayer";

        public override string Hint => "Przyznałeś losowemu graczowi losowy efekt na 10 sekund.";

        public override int Weight => 70;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Player randomPlayer = Util.RandomAlivePlayer();

            while (randomPlayer.Role == RoleTypeId.Scp079 || randomPlayer == player)
            {
                randomPlayer = Util.RandomAlivePlayer();
            }

            float duration = 10f;
            randomPlayer.ApplyRandomEffect(duration: duration);
            randomPlayer.ShowHint($"{player.Nickname} rzucił monetą.\nOtrzymałeś losowy efekt na {duration} sekund.");
        }
    }
}
