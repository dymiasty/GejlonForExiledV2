using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class O5Keycard : CoinPossibility
    {
        public override string Id => "O5Keycard";

        public override string Hint => "Dostałeś kartę <color=#1c1c1b>rady O5</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.KeycardO5);
        }
    }
}
