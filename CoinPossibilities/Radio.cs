using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class Radio : CoinPossibility
    {
        private static readonly string _hint = "Dostałeś <color=#b6fca7>radio</color>.";

        public Radio() : base("radio", 15, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.AddItem(ItemType.Radio);
        }
    }
}
