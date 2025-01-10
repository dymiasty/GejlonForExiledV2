using Exiled.API.Features;
using Exiled.API.Enums;
using MEC;

namespace GejlonForExiledV2.CoinPossibilities
{
    public class Ghost : CoinPossibility
    {
        private static readonly string _hint = "Stałeś się <color=#95baf5>duchem</color>." +
            "\n-Masz <color=#eef595>nieskończoną staminę</color>" +
            "\n-<color=#9af595>Szybciej</color> się poruszasz" +
            "\n-<color=#4c55cf>Możesz przechodzić przez drzwi</color>" +
            "\n-<color=#f0d5f7>Jesteś niewidzialny i niesłyszalny</color>" +
            "\n-<color=#e8828c>Nie możesz wykonywać żadnych interakcji</color>" +
            "\n-Efekt trwa <color=#ffc870>20</color> sekund.";

        public Ghost() : base("ghost", 25, _hint, PossibilityType.Positive) { }

        public override bool CanExecute(Player player) { return true; }

        public override void Execute(Player player)
        {
            HintDuration = 20f;

            float EffectDuration = 20f;

            player.EnableEffect(EffectType.Invigorated, EffectDuration);
            player.EnableEffect(EffectType.Ghostly, EffectDuration);
            player.EnableEffect(EffectType.Invisible, EffectDuration);
            player.EnableEffect(EffectType.MovementBoost, 100, EffectDuration);
            player.EnableEffect(EffectType.SilentWalk, 10, EffectDuration);
            Timing.RunCoroutine(Plugin.Instance.GodPlayer(player, EffectDuration));
            player.EnableEffect(EffectType.SeveredHands, EffectDuration - 0.1f);
        }   
    }
}
