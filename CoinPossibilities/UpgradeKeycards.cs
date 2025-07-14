using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class UpgradeKeycards : CoinPossibility
    {
        public override string Id => "upgradeKeycards";

        public override string Hint => "Wszystkie twoje karty dostępu\nzostały ulepszone o 1 poziom.";

        public override float HintDuration => 6f;

        public override int Weight => 60;

        public override PossibilityType possibilityType => PossibilityType.Positive;

        public override bool CanExecute(Player player)
        {
            foreach (Item item in player.Items.ToList())
            {
                if (item.IsKeycard)
                {
                    return true;
                }
            }

            return false;
        }

        public override void Execute(Player player)
        {
            foreach (Item item in player.Items.ToList())
            {
                if (item.IsKeycard)
                {
                    ItemType newKeycard = Plugin.Instance.UpgradeKeycard(item.Type);
                    player.RemoveItem(item);
                    player.AddItem(newKeycard);
                }
            }
        }
    }
}
