using Exiled.API.Features;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Candy : CoinPossibility
    {
        public override string Id => "candy";

        public override string Hint => "Dostałeś <color=#ff96e1>cukierki</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.TryAddCandy(Plugin.Instance.GenerateRandomCandy());
            player.TryAddCandy(Plugin.Instance.GenerateRandomCandy());
        }
    }
}
