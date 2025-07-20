using Exiled.API.Features;
using System.Runtime.Remoting.Messaging;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Candy : CoinPossibility
    {
        public override string Id => "candy";

        public override string Hint => "Dostałeś <color=#ff96e1>cukierki</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 75;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.TryAddCandy(Plugin.Instance.GenerateRandomCandy());
            player.TryAddCandy(Plugin.Instance.GenerateRandomCandy());
        }
    }
}
