using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class QuickDecontamination : CoinPossibility
    {
        public override string Id => "quickDecontamination";

        public override string Hint => "Uruchomiłeś szybką <color=#e6f564>dekontaminację LCZ</color>.";

        public override float HintDuration => 6f;

        public override int Weight => 65;

        public override PossibilityType possibilityType => PossibilityType.Mid;

        public override bool CanExecute(Player player)
        {
            if (Plugin.Instance.GetPeopleInLCZ().Count != 0)
                return true;

            return false;
        }

        public override void Execute(Player player)
        {
            Map.Broadcast(5, "\n<mark=yellow><color=#ffffa1><b>DEKONTAMINACJA</b></color></mark>\n LCZ zostało zdekontaminowane.");
            foreach (Player playerr in Plugin.Instance.GetPeopleInLCZ())
            {
                playerr.EnableEffect(EffectType.Decontaminating, 5f);
            }
            Door.LockAll(5f, ZoneType.LightContainment);
        }
    }
}
