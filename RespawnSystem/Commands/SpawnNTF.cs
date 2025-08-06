using CommandSystem;
using MEC;
using System;

namespace GejlonForExiledV2.RespawnSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SpawnNTF : ICommand
    {
        public string Command => "spawnntf";

        public string[] Aliases => null;

        public string Description => "Force spawns NTF.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            RespawnSystemCore Core = Plugin.Instance.RespawnSystemCore;

            Timing.KillCoroutines("mainRespawn");

            Core.MainCountdownStarted = false;

            Timing.RunCoroutine(Core.SpawnNTF(), "spawning");
            response = "Spawning NTF...";
            return true;
        }
    }
}
