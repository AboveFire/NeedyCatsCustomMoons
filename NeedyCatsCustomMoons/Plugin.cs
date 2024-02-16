using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace NeedyCatsCustomMoons
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static NeedyCatsCustomMoonsConfig NeedyCatsCustomMoonsConfig { get; internal set; }

        internal static ManualLogSource mls;

        private void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource("AboveFire.NeedyCatsCustomMoons");
            NeedyCatsCustomMoonsConfig = new(base.Config);
            var harmony = new Harmony("NeedyCatsCustomMoons");
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            harmony.PatchAll(typeof(NeedyCatPatch));
            mls.LogMessage($"Initialized {PluginInfo.PLUGIN_GUID}");
        }
    }
}
