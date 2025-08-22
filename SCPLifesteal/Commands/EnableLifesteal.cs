using CommandSystem;
using Exiled.API.Features;
using PlayerRoles;
using System;
using System.Linq;

namespace GejlonForExiledV2.SCPLifesteal.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class EnableLifesteal : ICommand
    {
        public string Command => "enablels";

        public string[] Aliases => new string[1] { "els" };

        public string Description => "Enables lifesteal for SCPs.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Plugin.Instance.SCPLifestealCore.SubscribeEvents();

            foreach (Player player in Player.List.ToList())
            {
                if (player.IsScp && player.Role != RoleTypeId.Scp0492)
                    player.ShowHint("Lifesteal włączony przez administratora.");
            }

            response = "Lifesteal enabled.";
            return true;
        }
    }
}
