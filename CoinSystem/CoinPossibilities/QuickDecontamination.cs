using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class QuickDecontamination : CoinPossibility
    {
        public override string Id => "quickDecontamination";

        public override string Hint => "Uruchomiłeś szybką <color=#e6f564>dekontaminację LCZ</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 60;

        public override PossibilityType Type => PossibilityType.Mid;

        public override bool CanExecute(Player player)
        {
            if (Util.GetPeopleInLCZ().Count != 0)
                return true;

            return false;
        }

        public override void Execute(Player player)
        {
            Map.Broadcast(5, "\n<mark=yellow><color=#ffffa1><b>DEKONTAMINACJA</b></color></mark>\n LCZ zostało zdekontaminowane.");
            foreach (Player playerr in Util.GetPeopleInLCZ())
            {
                playerr.EnableEffect(EffectType.Decontaminating, 5f);
            }
            Door.LockAll(5f, ZoneType.LightContainment);
        }
    }
}
