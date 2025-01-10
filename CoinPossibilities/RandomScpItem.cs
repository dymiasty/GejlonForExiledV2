using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomScpItem : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#fc03a9>losowy przedmiot SCP</color>.";

        public RandomScpItem() : base("randomScpItem", 35, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Plugin.Instance.GenerateRandomScpItem());
        }
    }
}
