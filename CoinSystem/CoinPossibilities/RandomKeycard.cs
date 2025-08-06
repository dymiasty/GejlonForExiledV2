using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class RandomKeycard : CoinPossibility
    {
        public override string Id => "randomKeycard";

        public override string Hint => "Dostałeś <color=#fc03a9>losową kartę</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 85;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Util.GenerateRandomKeycard());
        }
    }
}
