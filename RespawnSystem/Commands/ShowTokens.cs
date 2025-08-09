using CommandSystem;
using System;

namespace GejlonForExiledV2.RespawnSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ShowTokens : ICommand
    {
        public string Command => "tokens";

        public string[] Aliases => new string[1] { "tickets" };

        public string Description => "Get's current Tokens of NTF and CI.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = $"\n<color=blue>NTF: {Plugin.Instance.RespawnSystemCore.NineTailedFoxTokens}</color>\n" +
                $"<color=green>CI: {Plugin.Instance.RespawnSystemCore.ChaosTokens}</color>";
            return true;
        }
    }
}
