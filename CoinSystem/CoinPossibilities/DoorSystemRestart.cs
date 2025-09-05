using Exiled.API.Features;
using Exiled.API.Features.Doors;
using MEC;
using System.Collections.Generic;
using Exiled.API.Enums;
using System.Linq;
using GejlonForExiledV2.General;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class DoorSystemRestart : CoinPossibility
    {
        public override string Id => "doorsr";

        public override string Hint => "Zrestartowałeś system kontroli drzwi w placówce.";

        public override int Weight => 45;

        public override PossibilityType Type => PossibilityType.Negative;

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Timing.RunCoroutine(DSRCoroutine());
        }

        private IEnumerator<float> DSRCoroutine()
        {
            Cassie.MessageTranslated(
                "door control system malfunction detected . initializing repair",
                "Awaria systemu kontroli drzwi. Inicjowanie naprawy..."
                );
            foreach (Door door in Door.List.ToList())
            {
                if (door.Type != DoorType.Scp914Door && door.Type != DoorType.Airlock && !door.IsElevator)
                {
                    door.IsOpen = false;
                    door.Lock(25f, DoorLockType.NoPower);
                }
            }
            yield return Timing.WaitForSeconds(25f);
            Cassie.MessageTranslated(
                "door control system repair complete", 
                "Naprawa systemu kontroli drzwi zakończona."
                );
        }
    }
}
