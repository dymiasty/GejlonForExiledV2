using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class ClearInventory : CoinPossibility
    {
        public override string Id => "clearInventory";

        public override string Hint => "<color=#5c5c5b>Twój ekwipunek został wyczyszczony.</color>";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType possibilityType => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.ClearInventory();
        }
    }
}
