using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class UpgradeKeycards : CoinPossibility
    {
        private static readonly string _hint = 
            "Wszystkie twoje karty dostępu\n " +
            "zostały ulepszone o 1 poziom.";

        public UpgradeKeycards() : base("upgradeKeycard", 15, _hint, PossibilityType.Positive) { }

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
