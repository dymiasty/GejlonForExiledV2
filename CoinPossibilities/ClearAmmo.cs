using Exiled.API.Features;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class ClearAmmo : CoinPossibility
    {
        public override string Id => "clearAmmo";

        public override string Hint => "Wyczyszczono ci amunicję.";

        public override float HintDuration => 6f;

        public override int Weight => 65;

        public override PossibilityType possibilityType => PossibilityType.Negative;

        public override bool CanExecute(Player player)
        {
            if (player.Ammo.Count == 0)
            {
                return false;
            }

            return true;
        }

        public override void Execute(Player player)
        {
            player.ClearAmmo();
        }
    }
}
