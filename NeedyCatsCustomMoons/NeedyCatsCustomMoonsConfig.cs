using BepInEx.Configuration;

namespace NeedyCatsCustomMoons
{
    public class NeedyCatsCustomMoonsConfig
    {
        public static ConfigEntry<int> spawnRate;

        public NeedyCatsCustomMoonsConfig(ConfigFile cfg)
        {
            spawnRate = cfg.Bind(
                    "General.Toggles",
                    "Spawn rate",
                    20,
                    "The spawn rate of the cats on all moons (override the setting in NeedyCats config)"
            );
        }
    }
}
