using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class DowngradeKeycards : CoinPossibility
    {
        private static readonly string _hint = 
            "Wszystkie twoje karty dostępu\n " +
            "zostały zdegradowane o 1 poziom.";

        public DowngradeKeycards() : base("downgradeKeycard", 15, _hint, PossibilityType.Positive) { }

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
