using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class ClearKeycards : CoinPossibility
    {
        public override string Id => "clearKeycards";

        public override string Hint => "Zabrano ci wszystkie karty dostępu.";

        public override float HintDuration => 6f;

        public override int Weight => 70;

        public override PossibilityType possibilityType => PossibilityType.Negative;

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
