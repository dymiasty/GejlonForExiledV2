using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class DowngradeKeycards : CoinPossibility
    {
        public override string Id => "downgradeKeycards";

        public override string Hint =>
            "Wszystkie twoje karty dostępu\n " +
            "zostały zdegradowane o 1 poziom.";

        public override float HintDuration => 6f;

        public override int Weight => 50;

        public override PossibilityType Type => PossibilityType.Negative;

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
                    if (item.Type == ItemType.KeycardJanitor)
                    {
                        player.RemoveItem(item);
                        continue;
                    }
                    
                    ItemType newKeycard = Plugin.Instance.DowngradeKeycard(item.Type);
                    player.RemoveItem(item);
                    player.AddItem(newKeycard);
                }
            }
        }
    }
}
