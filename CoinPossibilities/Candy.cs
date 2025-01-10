using Exiled.API.Features;
using System.Runtime.Remoting.Messaging;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Candy : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#ff96e1>cukierki</color>.";

        public Candy() : base("candy", 15, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.TryAddCandy(Plugin.Instance.GenerateRandomCandy());
            player.TryAddCandy(Plugin.Instance.GenerateRandomCandy());
        }
    }
}
