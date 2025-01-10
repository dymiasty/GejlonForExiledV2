using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class OneHp : CoinPossibility
    {
        private static readonly string _hint = "Twoje <color=#fc0328>zdrowie</color> zostało zmniejszone do <color=#fc0328>1</color>.";

        public OneHp() : base("oneHP", 25, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.Health = 1f;
        }
    }
}
