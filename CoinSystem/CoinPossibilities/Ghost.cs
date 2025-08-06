using Exiled.API.Features;
using Exiled.API.Enums;
using MEC;

namespace GejlonForExiledV2.CoinSystem.CoinPossibilities
{
    public class Ghost : CoinPossibility
    {
        public override string Id => "ghost";

        public override string Hint =>
            "Stałeś się <color=#95baf5>duchem</color>." +
            "\n-Masz <color=#eef595>nieskończoną staminę</color>" +
            "\n-<color=#9af595>Szybciej</color> się poruszasz" +
            "\n-<color=#4c55cf>Możesz przechodzić przez drzwi</color>" +
            "\n-<color=#f0d5f7>Jesteś niewidzialny i niesłyszalny</color>" +
            "\n-<color=#e8828c>Nie możesz wykonywać żadnych interakcji</color>" +
            "\n-Efekt trwa <color=#ffc870>20</color> sekund.";

        public override float HintDuration => 18f;

        public override int Weight => 70;

        public override PossibilityType Type => PossibilityType.Positive;

        public override bool CanExecute(Player player)
        {
            if (player.CurrentRoom.Type == RoomType.Pocket)
            {
                return false;
            }

            return true;
        }

        public override void Execute(Player player)
        {
            float EffectDuration = 20f;

            player.EnableEffect(EffectType.Invigorated, EffectDuration);
            player.EnableEffect(EffectType.Ghostly, EffectDuration);
            player.EnableEffect(EffectType.Invisible, EffectDuration);
            player.EnableEffect(EffectType.MovementBoost, 100, EffectDuration);
            player.EnableEffect(EffectType.SilentWalk, 10, EffectDuration);
            Timing.RunCoroutine(Util.GodPlayer(player, EffectDuration));
            player.EnableEffect(EffectType.SeveredHands, EffectDuration - 0.1f);
        }   
    }
}
