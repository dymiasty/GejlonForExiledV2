using Exiled.API.Interfaces;

namespace GejlonForExiledV2
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
    }
}