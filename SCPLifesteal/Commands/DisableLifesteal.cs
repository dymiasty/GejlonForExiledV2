using CommandSystem;
using Exiled.API.Features;
using PlayerRoles;
using System;
using System.Linq;

namespace GejlonForExiledV2.SCPLifesteal.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class DisableLifesteal : ICommand
    {
        public string Command => "disablels";

        public string[] Aliases => new string[1] { "dls" };

        public string Description => "Disables lifesteal SCPs.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Plugin.Instance.SCPLifestealCore.UnsubscribeEvents();

            foreach (Player player in Player.List.ToList())
            {
                if (player.IsScp && player.Role != RoleTypeId.Scp0492)
                    player.ShowHint("Lifesteal wyłączony przez administratora.");
            }

            response = "Lifesteal disabled.";
            return true;
        }
    }
}
