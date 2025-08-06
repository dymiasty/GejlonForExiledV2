using CommandSystem;
using MEC;
using System;

namespace GejlonForExiledV2.RespawnSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class StopRespawn : ICommand
    {
        public string Command => "stoprespawn";

        public string[] Aliases => null;

        public string Description => "Stops current respawn countdown.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            RespawnSystemCore Core = Plugin.Instance.RespawnSystemCore;

            Timing.KillCoroutines("mainRespawn");
            Timing.KillCoroutines("respawnTimer");

            Plugin.Instance.RespawnTimerCore.Spectators.Clear();

            if (Core.IsRespawning)
            {
                Timing.KillCoroutines("spawning");
            }

            Core.MainCountdownStarted = false;

            response = "Successfully stopped next respawn wave.";
            return true;
        }
    }
}
