using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Collections.Generic;
using System.Linq;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class ClearKeycards : CoinPossibility
    {
        private static readonly string _hint = "Zabrano ci wszystkie karty dostępu.";

        public ClearKeycards() : base("clearKeycards", 30, _hint, PossibilityType.Negative) { }

        public override bool CanExecute(Player player)
        {
            foreach (Item item in player.Items.ToList())
            {
                if (item.IsKeycard) return true;
            }

            return false;
        }

        public override void Execute(Player player)
        {
            foreach (Item item in player.Items.ToList())
            {
                if (item.IsKeycard)
                {
                    player.RemoveItem(item);
                }       
            }
        }
    }
}
