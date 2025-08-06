using CommandSystem;
using MEC;
using System;

namespace GejlonForExiledV2.RespawnSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SpawnCI : ICommand
    {
        public string Command => "spawnci";

        public string[] Aliases => null;

        public string Description => "Force spawns CI.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            RespawnSystemCore Core = Plugin.Instance.RespawnSystemCore;

            Timing.KillCoroutines("mainRespawn");
            
            Core.MainCountdownStarted = false;

            Timing.RunCoroutine(Core.SpawnCI(), "spawning");
            response = "Spawning CI...";
            return true;
        }
    }
}
