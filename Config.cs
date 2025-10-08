using Exiled.API.Interfaces;
using System.ComponentModel;

namespace GejlonForExiledV2
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;


        [Description("Dictates whether the plugin should automatically disable Dead Man's on round start.")]
        public bool AutoDeadmanDisable = true;

        [Description("Dictates whether coin flipping mechanics should be enabled.")]
        public bool CoinsEnabled { get; set; } = true;

        [Description("Dictates whether old respawn system should be enabled.")]
        public bool OldRespawnSystemEnabled { get; set; } = true;

        [Description("An addon for old respawn system - Dictates whether the respawn timer should be enabled.")]
        public bool RespawnTimer { get; set; } = true;

        [Description("Dictates whether reviving players with medkits should be enabled.")]
        public bool RevivingEnabled { get; set; } = true;

        [Description("Dictates whether the lifesteal for SCPs should be enabled.")]
        public bool SCPLifestealEnabled { get; set; } = true;

        [Description("Dictates whether weapon jamming should be enabled.")]
        public bool WeaponJammingEnabled { get; set; } = true;
    }
}