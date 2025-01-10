using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class ClearAmmo : CoinPossibility
    {
        private static readonly string _hint = "Jeśli taką posiadałeś, to wyczyszczono ci amunicję.";

        public ClearAmmo() : base("clearAmmo", 30, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            player.ClearAmmo();
        }
    }
}
