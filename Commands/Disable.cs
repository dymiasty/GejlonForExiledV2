using CommandSystem;
using Exiled.API.Features;
using System;

namespace GejlonForExiledV2.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Disable : ICommand
    {
        public string Command => "gfedisable";

        public string[] Aliases => null;

        public string Description => "Disable GFEV2";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Log.Info("Wyłączanie GFEV2...");
            Plugin.Instance.OnDisabled();
            response = "Wyłączono plugin GFEV2.";
            return true;
        }
    }
}
