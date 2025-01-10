using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class ClearInventory : CoinPossibility
    {
        private static readonly string _hint = "<color=#5c5c5b>Twój ekwipunek został wyczyszczony.</color>";

        public ClearInventory() : base("clearInventory", 25, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.ClearInventory();
        }
    }
}
