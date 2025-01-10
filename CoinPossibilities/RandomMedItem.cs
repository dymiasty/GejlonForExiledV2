using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class RandomMedItem : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#fc03a9>losowy przedmiot leczący</color>.";

        public RandomMedItem() : base("randomMedItem", 25, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(Plugin.Instance.GenerateRandomMedicalItem());
        }
    }
}
