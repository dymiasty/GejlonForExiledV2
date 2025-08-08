using Exiled.API.Features;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomSpecialWeapon : CoinPossibility
    {
        public override string Id => "randomSpecialWeapon";

        public override string Hint => "Dostałeś <color=#fc03a9>losową broń specjalną</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 80;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Util.GenerateRandomSpecialWeapon());
        }
    }
}
