using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using System.Collections.Generic;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class QuickDecontamination : CoinPossibility
    {
        private static readonly string _hint = "Uruchomiłeś szybką <color=#e6f564>dekontaminację LCZ</color>.";

        public QuickDecontamination() : base("quickDecon", 30, _hint, PossibilityType.Mid) { }

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
