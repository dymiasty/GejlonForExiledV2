using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomKeycard : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#fc03a9>losową kartę</color>.";

        public RandomKeycard() : base("randomKeycard", 25, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Plugin.Instance.GenerateRandomKeycard());
        }
    }
}
