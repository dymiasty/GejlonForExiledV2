using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class O5Keycard : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś kartę <color=#1c1c1b>rady O5</color>.";

        public O5Keycard() : base("O5Keycard", 25, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.KeycardO5);
        }
    }
}
