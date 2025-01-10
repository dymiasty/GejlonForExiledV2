using Exiled.API.Features;
using Exiled.API.Features.Doors;
using MEC;
using System.Collections.Generic;


namespace GejlonForExiledV2.CoinPossibilities
{
    public class DoorSystemRestart : CoinPossibility
    {
        private static readonly string _hint = "Zrestartowałeś system kontroli drzwi w placówce.";

        public DoorSystemRestart() : base("doorsr", 30, _hint, PossibilityType.Mid) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            Cassie.MessageTranslated(
                "door control system malfunction detected . initializing repair", 
                "Awaria systemu kontroli drzwi. Inicjowanie naprawy..."
                );
            Door.LockAll(25f, Exiled.API.Enums.DoorLockType.Regular079);
            Timing.RunCoroutine(messageDelay());
        }

        private IEnumerator<float> messageDelay()
        {
            yield return Timing.WaitForSeconds(25f);
            Cassie.MessageTranslated(
                "door control system repair complete", 
                "Naprawa systemu kontroli drzwi zakończona."
                );
        }
    }
}
