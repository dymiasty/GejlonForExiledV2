using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace GejlonForExiledV2.SCPLifesteal
{
    public class EventHandlers
    {
        public const float LIFESTEAL_MULTIPLIER = 0.85f;

        public void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            if (ev.Player.IsScp && ev.Player.Role != RoleTypeId.Scp0492)
            {
                ev.Player.ShowHint($"Lifesteal włączony.\nLeczysz się za {LIFESTEAL_MULTIPLIER*100}% zadawanych obrażeń", 6f);
            }
        }

        public void OnPlayerHurt(HurtEventArgs ev)
        {
            if (ev.Attacker.IsScp && ev.Attacker.Role != RoleTypeId.Scp0492)
            {
                if (ev.Attacker.Role == RoleTypeId.Scp173)
                    ev.Attacker.Heal(ev.Player.MaxHealth * LIFESTEAL_MULTIPLIER);
                else
                    ev.Attacker.Heal(ev.Amount * LIFESTEAL_MULTIPLIER);
            }
        }
    }
}
